using eEscola.Application.Models;
using eEscola.Application.Results;
using eEscola.Domain.Entities;

namespace eEscola.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<Result<int>> CadastrarAsync(Usuario usuario);
        Task<Result<UsuarioTokenModel>> LoginAsync(Usuario usuario);
    }
}
