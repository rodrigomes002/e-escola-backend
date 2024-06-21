using eEscola.API.Models;

namespace eEscola.API.Repository
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
