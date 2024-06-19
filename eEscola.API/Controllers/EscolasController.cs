using eEscola.API.Models;
using eEscola.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/escolas")]
    [ApiController]
    public class EscolasController : ControllerBase
    {
        private readonly IEscolaRepository _escolaRepository;

        public EscolasController(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _escolaRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Escola escola)
        {
            if (await _escolaRepository.Add(escola))
            {
                return Ok("Cadastro realizado com sucesso!");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Escola escola)
        {
            var escolaDb = await _escolaRepository.GetById(id);
            escolaDb.Nome = escola.Nome;
            escolaDb.CNPJ = escola.CNPJ;

            if (await _escolaRepository.Edit(escolaDb))
            {
                return Ok("Update realizado com sucesso!");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var escolaDb = await _escolaRepository.GetById(id);

            if (escolaDb is not null)
            {
                await _escolaRepository.Delete(id);
                return Ok("Excluído com sucesso!");
            }

            return BadRequest();
        }
    }
}
