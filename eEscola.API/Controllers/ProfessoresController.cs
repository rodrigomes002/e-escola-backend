using eEscola.API.Models;
using eEscola.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/professores")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessoresController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _professorRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Professor professor)
        {
            if (await _professorRepository.Add(professor))
            {
                return Ok("Cadastro realizado com sucesso!");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Professor professor)
        {
            var professorDb = await _professorRepository.GetById(id);
            professorDb.Nome = professor.Nome;
            professorDb.CPF = professor.CPF;

            if (await _professorRepository.Edit(professorDb))
            {
                return Ok("Update realizado com sucesso!");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var professorDb = await _professorRepository.GetById(id);

            if (professorDb is not null)
            {
                await _professorRepository.Delete(id);
                return Ok("Excluído com sucesso!");
            }

            return BadRequest();
        }
    }
}
