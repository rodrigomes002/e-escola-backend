using eEscola.Domain.Entities;

namespace eEscola.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> GetById(int id);
        Task<bool> Add(Aluno aluno);
        Task<bool> Edit(Aluno aluno);
        Task<bool> Delete(int id);
    }
}
