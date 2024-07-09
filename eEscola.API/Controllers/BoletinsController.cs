using eEscola.API.Controllers.Base;
using eEscola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/boletins")]
    [ApiController]
    public class BoletinsController : BaseController
    {
        private readonly IBoletimApplication _boletimApplication;

        public BoletinsController(IBoletimApplication boletimApplication)
        {
            _boletimApplication = boletimApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _boletimApplication.GetAll();

            return Ok(result.Object);
        }
    }
}
