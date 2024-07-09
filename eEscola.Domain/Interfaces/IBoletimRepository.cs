using eEscola.Domain.Entities;

namespace eEscola.Domain.Interfaces
{
    public interface IBoletimRepository
    {
        Task<IEnumerable<Boletim>> GetAll();
    }
}
