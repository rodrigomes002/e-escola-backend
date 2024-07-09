using eEscola.Application.Interfaces;
using eEscola.Application.Results;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eEscola.Application
{
    public class EscolaApplication : IEscolaApplication
    {
        private readonly IEscolaRepository _escolaRespository;

        public EscolaApplication(IEscolaRepository escolaRespository)
        {
            _escolaRespository = escolaRespository;
        }

        public async Task<Result<bool>> Add(Escola escola)
        {
            var result = await _escolaRespository.Add(escola);

            if (!result)
                return Result<bool>.Error("Erro ao cadastrar escola.");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var escolaDb = await _escolaRespository.GetById(id);

            if (escolaDb is null)
                return Result<bool>.NotFoundResult();

            var result = await _escolaRespository.Delete(id);

            if (!result)
                return Result<bool>.Error("Erro ao deletar escola");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<bool>> Edit(int id, Escola escola)
        {
            var escolaDb = await _escolaRespository.GetById(id);

            if (escolaDb is null)
                return Result<bool>.NotFoundResult();

            escolaDb.Nome = escola.Nome;
            escolaDb.CNPJ = escola.CNPJ;

            var result = await _escolaRespository.Edit(escolaDb);

            if (!result)
                return Result<bool>.Error("Erro ao atualizar escola.");

            return Result<bool>.Ok(result);
        }

        public async Task<Result<IEnumerable<Escola>>> GetAll()
        {
            var escolas = await _escolaRespository.GetAll();

            return Result<IEnumerable<Escola>>.Ok(escolas);
        }

        public async Task<Result<Escola>> GetById(int id)
        {
            var escola = await _escolaRespository.GetById(id);

            if (escola is null)
                return Result<Escola>.NotFoundResult();

            return Result<Escola>.Ok(escola);
        }
    }
}
