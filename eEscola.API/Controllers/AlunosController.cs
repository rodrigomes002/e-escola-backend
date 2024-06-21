using eEscola.API.Models;
using eEscola.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunosController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _alunoRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Aluno aluno)
        {
            if (await _alunoRepository.Add(aluno))
            {
                return Ok("Cadastro realizado com sucesso!");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Aluno aluno)
        {
            var alunoDb = await _alunoRepository.GetById(id);
            alunoDb.Nome = aluno.Nome;
            aluno.CPF = alunoDb.CPF;

            if (await _alunoRepository.Edit(alunoDb))
            {
                return Ok("Update realizado com sucesso!");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var alunoDb = await _alunoRepository.GetById(id);

            if (alunoDb is not null)
            {
                await _alunoRepository.Delete(id);
                return Ok("Excluído com sucesso!");
            }

            return BadRequest();
        }
    }
}
