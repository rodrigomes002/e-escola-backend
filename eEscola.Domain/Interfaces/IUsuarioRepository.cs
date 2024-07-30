using eEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eEscola.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByUsernameAsync(string username);
        Task<int> CadastrarAsync(Usuario usuario);
    }
}
