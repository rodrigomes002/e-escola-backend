using eEscola.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/boletins")]
    [ApiController]
    public class BoletinsController : ControllerBase
    {
        private readonly IBoletimRepository _boletimRepository;

        public BoletinsController(IBoletimRepository boletimRepository)
        {
            _boletimRepository = boletimRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _boletimRepository.GetAll());
        }
    }
}
