using eEscola.Application.Models;
using eEscola.Application.Results;
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

        public async Task<Result<bool>> Add(Aluno aluno)
        {
            var result = await _alunoRepository.Add(aluno);

            if (!result)
                return Result<bool>.Error("Erro ao cadastrar Aluno");

            return Result<bool>.Ok(result);
        }

        public Task<Result<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Edit(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Aluno>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Aluno>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
