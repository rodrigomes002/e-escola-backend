using eEscola.Application.Models;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;

namespace eEscola.Application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoApplication(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<bool> Add(AlunoModel model)
        {
            var aluno = new Aluno(model.Nome, model.CPF);

            return await _alunoRepository.Add(aluno);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(AlunoModel aluno)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> GetAll()
        {
            return _alunoRepository.GetAll();
        }

        public Task<Aluno> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
