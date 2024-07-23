using eEscola.Application.Models;
using eEscola.Domain.Entities;

namespace eEscola.Application.Interfaces
{
    public interface IJwtProvider
    {
        UsuarioTokenModel Generate(Usuario user);
    }
}
