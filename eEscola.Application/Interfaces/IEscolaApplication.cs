using eEscola.Application.Results;
using eEscola.Domain.Entities;

namespace eEscola.Application.Interfaces
{
    public interface IEscolaApplication
    {
        Task<Result<IEnumerable<Escola>>> GetAll();
        Task<Result<Escola>> GetById(int id);
        Task<Result<bool>> Add(Escola escola);
        Task<Result<bool>> Edit(int id, Escola escola);
        Task<Result<bool>> Delete(int id);
    }
}
