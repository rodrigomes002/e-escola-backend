using eEscola.API.Models;

namespace eEscola.API.Interfaces
{
    public interface IBoletimRepository
    {
        Task<IEnumerable<Boletim>> GetAll();
    }
}
