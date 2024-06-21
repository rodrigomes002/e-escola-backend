using eEscola.API.Models;

namespace eEscola.API.Interfaces
{
    public interface IEscolaRepository
    {
        Task<IEnumerable<Escola>> GetAll();
        Task<Escola> GetById(int id);
        Task<bool> Add(Escola escola);
        Task<bool> Edit(Escola escola);
        Task<bool> Delete(int id);
    }
}