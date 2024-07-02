using eEscola.Application.Interfaces;
using eEscola.Application.Results;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;

namespace eEscola.Application
{
    public class BoletimApplication : IBoletimApplication
    {
        private readonly IBoletimRepository _boletimRepository;

        public BoletimApplication(IBoletimRepository boletimRepository)
        {
            _boletimRepository = boletimRepository;
        }

        public async Task<Result<IEnumerable<Boletim>>> GetAll()
        {
            var boletins = await _boletimRepository.GetAll();

            return Result<IEnumerable<Boletim>>.Ok(boletins);
        }
    }
}
