using eEscola.Application.Interfaces;
using eEscola.Application.Results;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;

namespace eEscola.Application
{
    public class ProfessorApplication : IProfessorApplication
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorApplication(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<Result<bool>> Add(Professor professor)
        {
            var result = await _professorRepository.Add(professor);

            if (!result)
                return Result<bool>.Error("Erro ao cadastrar professor");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var professorDb = await _professorRepository.GetById(id);

            if (professorDb is null)
                return Result<bool>.NotFoundResult();

            var result = await _professorRepository.Delete(id);

            if (!result)
                return Result<bool>.Error("Erro ao deletar professor");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<bool>> Edit(int id, Professor professor)
        {
            var professorDb = await _professorRepository.GetById(id);

            if (professorDb is null)
                return Result<bool>.NotFoundResult();

            var result = await _professorRepository.Edit(professorDb);

            if (!result)
                return Result<bool>.Error("Erro ao atualizar professor");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<IEnumerable<Professor>>> GetAll()
        {
            var result = await _professorRepository.GetAll();

            return Result<IEnumerable<Professor>>.Ok(result);
        }

        public async Task<Result<Professor>> GetById(int id)
        {
            var professor = await _professorRepository.GetById(id);

            if (professor is null)
                return Result<Professor>.NotFoundResult();

            return Result<Professor>.Ok(professor);
        }
    }
}
