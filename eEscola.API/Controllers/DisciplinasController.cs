using eEscola.API.Controllers.Base;
using eEscola.Application.Interfaces;
using eEscola.Application.Models;
using eEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/disciplinas")]
    [ApiController]
    public class DisciplinasController : BaseController
    {
        private readonly IDisciplinaApplication _disciplinaApplication;

        public DisciplinasController(IDisciplinaApplication disciplinaApplication)
        {
            _disciplinaApplication = disciplinaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _disciplinaApplication.GetAll();

            return Ok(result.Object);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DisciplinaModel model)
        {
            var disciplina = new Disciplina(model.Nome);

            if (!disciplina.IsValid)
                return BadRequest(disciplina.Notifications);

            var result = await _disciplinaApplication.Add(disciplina);

            if (!result.Sucess)
                return BadRequest(disciplina.Notifications);

            return Ok($"Disciplina {disciplina.Nome} cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DisciplinaModel model)
        {
            var disciplina = new Disciplina(model.Nome);

            if (!disciplina.IsValid)
                return BadRequest(disciplina.Notifications);

            var result = await _disciplinaApplication.Edit(id, disciplina);

            if (result.NotFound)
                return NotFound();

            if (!result.Sucess)
                return BadRequest(disciplina.Notifications);

            return Ok("Update realizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _disciplinaApplication.Delete(id);

            if (result.NotFound)
                return NotFound();

            if (!result.Sucess)
                return BadRequest(result.Notifications);

            return Ok("Disciplina excluída com sucesso!");
        }
    }
}
