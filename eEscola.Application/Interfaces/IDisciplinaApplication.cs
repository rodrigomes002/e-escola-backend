using eEscola.Application.Results;
using eEscola.Domain.Entities;

namespace eEscola.Application.Interfaces
{
    public interface IDisciplinaApplication
    {
        Task<Result<IEnumerable<Disciplina>>> GetAll();
        Task<Result<Disciplina>> GetById(int id);
        Task<Result<bool>> Add(Disciplina disciplina);
        Task<Result<bool>> Edit(int id, Disciplina disciplina);
        Task<Result<bool>> Delete(int id);
    }
}
