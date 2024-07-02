using eEscola.Application.Interfaces;
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
                return Result<bool>.Error("Erro ao cadastrar aluno");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var alunoDb = await _alunoRepository.GetById(id);

            if (alunoDb is null)
                return Result<bool>.NotFoundResult();

            var result = await _alunoRepository.Delete(id);

            if (!result)
                return Result<bool>.Error("Erro ao deletar aluno");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<bool>> Edit(int id, Aluno aluno)
        {
            var alunoDb = await _alunoRepository.GetById(id);

            if (alunoDb is null)
                return Result<bool>.NotFoundResult();

            alunoDb.Nome = aluno.Nome;
            alunoDb.CPF = aluno.CPF;

            var result = await _alunoRepository.Edit(alunoDb);

            if (!result)
                return Result<bool>.Error("Erro ao atualizar aluno");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<IEnumerable<Aluno>>> GetAll()
        {
            var alunos = await _alunoRepository.GetAll();

            return Result<IEnumerable<Aluno>>.Ok(alunos);
        }

        public async Task<Result<Aluno>> GetById(int id)
        {
            var aluno = await _alunoRepository.GetById(id);

            if (aluno is null)
                return Result<Aluno>.NotFoundResult();

            return Result<Aluno>.Ok(aluno);
        }
    }
}
