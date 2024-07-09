using eEscola.Application.Interfaces;
using eEscola.Application.Models;
using eEscola.Application.Results;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;

namespace eEscola.Application
{
    public class DisciplinaApplication : IDisciplinaApplication
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinaApplication(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task<Result<bool>> Add(Disciplina disciplina)
        {
            var result = await _disciplinaRepository.Add(disciplina);

            if (!result)
                return Result<bool>.Error("Erro ao cadastrar disciplina.");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var disciplinaDb = await _disciplinaRepository.GetById(id);

            if (disciplinaDb is null)
                return Result<bool>.NotFoundResult();

            var result = await _disciplinaRepository.Delete(id);

            if (!result)
                return Result<bool>.Error("Erro ao deletar disciplina.");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<bool>> Edit(int id, Disciplina disciplina)
        {
            var disciplinaDb = await _disciplinaRepository.GetById(id);

            if (disciplinaDb is null)
                return Result<bool>.NotFoundResult();

            disciplinaDb.Nome = disciplina.Nome;

            var result = await _disciplinaRepository.Edit(disciplinaDb);

            if (!result)
                return Result<bool>.Error("Erro ao atualizar disciplina.");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<IEnumerable<Disciplina>>> GetAll()
        {
            var disciplinas = await _disciplinaRepository.GetAll();

            return Result<IEnumerable<Disciplina>>.Ok(disciplinas);
        }

        public async Task<Result<Disciplina>> GetById(int id)
        {
            var disciplina = await _disciplinaRepository.GetById(id);

            if (disciplina is null)
                return Result<Disciplina>.NotFoundResult();

            return Result<Disciplina>.Ok(disciplina);
        }
    }
}
