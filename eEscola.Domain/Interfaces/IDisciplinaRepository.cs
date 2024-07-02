using eEscola.Domain.Entities;

namespace eEscola.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<IEnumerable<Disciplina>> GetAll();
        Task<Disciplina> GetById(int id);
        Task<bool> Add(Disciplina disciplina);
        Task<bool> Edit(Disciplina disciplina);
        Task<bool> Delete(int id);

    }
}
