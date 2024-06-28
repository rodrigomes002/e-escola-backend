using eEscola.Application.Models;
using eEscola.Domain.Entities;

namespace eEscola.Application
{
    public interface IAlunoApplication
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> GetById(int id);
        Task<bool> Add(AlunoModel aluno);
        Task<bool> Edit(AlunoModel aluno);
        Task<bool> Delete(int id);
    }
}
