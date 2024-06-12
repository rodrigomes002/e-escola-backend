using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/escolas")]
    [ApiController]
    public class EscolasController : ControllerBase
    {
        public EscolasController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
