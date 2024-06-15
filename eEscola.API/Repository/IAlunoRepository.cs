using eEscola.API.Models;

namespace eEscola.API.Repository
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> GetAll();
        Task<Aluno> GetById(int id);
        Task<bool> Add(Aluno aluno);
        Task<bool> Edit(Aluno aluno);
        Task<bool> Delete(int id);
    }
}
