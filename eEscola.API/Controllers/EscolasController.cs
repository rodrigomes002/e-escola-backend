using eEscola.API.Controllers.Base;
using eEscola.Application.Interfaces;
using eEscola.Application.Models;
using eEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/escolas")]
    [ApiController]
    public class EscolasController : BaseController
    {
        private readonly IEscolaApplication _escolaApplication;

        public EscolasController(IEscolaApplication escolaApplication)
        {
            _escolaApplication = escolaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _escolaApplication.GetAll();

            return Ok(result.Object);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EscolaModel model)
        {
            var escola = new Escola(model.Nome, model.CNPJ);

            if (!escola.IsValid)
                return BadRequest(escola.Notifications);

            var result = await _escolaApplication.Add(escola);

            if (!result.Sucess)
                return BadRequest(escola.Notifications);

            return Ok($"Escola {escola.Nome} cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EscolaModel model)
        {
            var escola = new Escola(model.Nome, model.CNPJ);

            if (!escola.IsValid)
                return BadRequest(escola.Notifications);

            var result = await _escolaApplication.Edit(id, escola);

            if (!result.Sucess)
                return BadRequest(escola.Notifications);

            return Ok("Update realizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _escolaApplication.Delete(id);

            if (result.NotFound)
                return NotFound();

            if (!result.Sucess)
                return BadRequest(result.Notifications);

            return Ok("Escola excluída com sucesso!");
        }
    }
}
