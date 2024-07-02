using eEscola.Application.Results;
using eEscola.Domain.Entities;

namespace eEscola.Application.Interfaces
{
    public interface IProfessorApplication
    {
        Task<Result<IEnumerable<Professor>>> GetAll();
        Task<Result<Professor>> GetById(int id);
        Task<Result<bool>> Add(Professor professor);
        Task<Result<bool>> Edit(int id, Professor professor);
        Task<Result<bool>> Delete(int id);
    }
}
