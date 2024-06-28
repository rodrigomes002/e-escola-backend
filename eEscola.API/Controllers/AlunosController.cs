using eEscola.API.Controllers.Base;
using eEscola.Application;
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
            return Ok(await _alunoApplication.GetAll());
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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] AlunoModel aluno)
        //{
        //    var alunoDb = await _alunoApplication.GetById(id);
        //    alunoDb.Nome = aluno.Nome;
        //    aluno.CPF = alunoDb.CPF;

        //    if (await _alunoApplication.Edit(alunoDb))
        //    {
        //        return Ok("Update realizado com sucesso!");
        //    }

        //    return BadRequest();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var alunoDb = await _alunoApplication.GetById(id);

            if (alunoDb is not null)
            {
                await _alunoApplication.Delete(id);
                return Ok("Excluído com sucesso!");
            }

            return BadRequest();
        }
    }
}
