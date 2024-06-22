using eEscola.API.Interfaces;
using eEscola.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/disciplinas")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinasController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _disciplinaRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Disciplina disciplina)
        {
            if (await _disciplinaRepository.Add(disciplina))
            {
                return Ok("Cadastro realizado com sucesso!");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Disciplina disciplina)
        {
            var disciplinaDb = await _disciplinaRepository.GetById(id);
            disciplinaDb.Nome = disciplina.Nome;

            if (await _disciplinaRepository.Edit(disciplinaDb))
            {
                return Ok("Update realizado com sucesso");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var disciplina = await _disciplinaRepository.GetById(id);

            if (disciplina is not null)
            {
                await _disciplinaRepository.Delete(id);
                return Ok("Excluído com sucesso!");
            }

            return BadRequest();
        }
    }
}
