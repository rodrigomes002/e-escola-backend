using eEscola.API.Controllers.Base;
using eEscola.Application.Interfaces;
using eEscola.Application.Models;
using eEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunosController : BaseController
    {
        private readonly IAlunoApplication _alunoApplication;

        public AlunosController(IAlunoApplication alunoApplication)
        {
            _alunoApplication = alunoApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _alunoApplication.GetAll();

            return Ok(result.Object);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlunoModel model)
        {
            var aluno = new Aluno(model.Nome, model.CPF);

            if (!aluno.IsValid)
                return BadRequest(aluno.Notifications);

            var result = await _alunoApplication.Add(aluno);

            if (!result.Sucess)
                return BadRequest(result.Notifications);

            return Ok($"Aluno {aluno.Nome} cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlunoModel model)
        {
            var aluno = new Aluno(model.Nome, model.CPF);

            if (!aluno.IsValid)
                return BadRequest(aluno.Notifications);

            var result = await _alunoApplication.Edit(id, aluno);

            if (result.NotFound)
                return NotFound();

            if (!result.Sucess)
                return BadRequest(result.Notifications);

            return Ok("Update realizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _alunoApplication.Delete(id);

            if (result.NotFound)
                return NotFound();

            if (!result.Sucess)
                return BadRequest(result.Notifications);

            return Ok("Aluno excluído com sucesso!");
        }
    }
}
