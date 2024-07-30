using eEscola.API.Controllers.Base;
using eEscola.Application.Interfaces;
using eEscola.Application.Models;
using eEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuariosController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UsuarioModel model)
        {
            var usuario = new Usuario(model.Username, model.Password);

            if (!usuario.IsValid)
                return BadRequest(usuario.Notifications);

            var result = await _usuarioApplication.CadastrarAsync(usuario);

            if (!result.IsValid)
                return BadRequest(result.Notifications);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioModel model)
            {
            var usuario = new Usuario(model.Username, model.Password);

            if (!usuario.IsValid)
                return BadRequest(usuario.Notifications);

            var result = await _usuarioApplication.LoginAsync(usuario);

            if (result.NotFound)
                return NotFound();

            return Ok(result);
        }

    }
}
