using eEscola.API.Controllers.Base;
using eEscola.Application.Interfaces;
using eEscola.Application.Models;
using eEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/professores")]
    [ApiController]
    public class ProfessoresController : BaseController
    {
        private readonly IProfessorApplication _professorApplication;

        public ProfessoresController(IProfessorApplication professorApplication)
        {
            _professorApplication = professorApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _professorApplication.GetAll();

            return Ok(result.Object);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfessorModel model)
        {
            var professor = new Professor(model.Nome, model.CPF);

            if (!professor.IsValid)
                return BadRequest(professor.Notifications);

            var result = await _professorApplication.Add(professor);

            if (!result.Sucess)
                return BadRequest(result.Notifications);

            return Ok($"Professor {professor.Nome} cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProfessorModel model)
        {
            var professor = new Professor(model.Nome, model.CPF);

            if (!professor.IsValid)
                return BadRequest(professor.Notifications);

            var result = await _professorApplication.Edit(id, professor);

            if (result.NotFound)
                return NotFound();

            if (!result.Sucess)
                return BadRequest(result.Notifications);

            return Ok("Update realizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _professorApplication.Delete(id);

            if (result.NotFound)
                return NotFound();

            if (!result.Sucess)
                return BadRequest(result.Notifications);

            return Ok("Professor excluído com sucesso!");
        }
    }
}
