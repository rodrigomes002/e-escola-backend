using eEscola.API.Models;

namespace eEscola.API.Repository
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetAll();
        Task<Professor> GetById(int id);
        Task<bool> Add(Professor professor);
        Task<bool> Edit(Professor professor);
        Task<bool> Delete(int id);
    }
}
