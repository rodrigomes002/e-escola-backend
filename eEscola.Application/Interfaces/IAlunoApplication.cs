using eEscola.Application.Results;
using eEscola.Domain.Entities;

namespace eEscola.Application.Interfaces
{
    public interface IAlunoApplication
    {
        Task<Result<IEnumerable<Aluno>>> GetAll();
        Task<Result<Aluno>> GetById(int id);
        Task<Result<bool>> Add(Aluno aluno);
        Task<Result<bool>> Edit(int id, Aluno aluno);
        Task<Result<bool>> Delete(int id);
    }
}
