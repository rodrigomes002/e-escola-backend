using eEscola.Application.Interfaces;
using eEscola.Application.Models;
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
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly ICryptographyProvider _cryptographyProvider;

        public UsuarioApplication(IUsuarioRepository usuarioRepository, IJwtProvider jwtProvider, ICryptographyProvider cryptographyProvider)
        {
            _usuarioRepository = usuarioRepository;
            _jwtProvider = jwtProvider;
            _cryptographyProvider = cryptographyProvider;
        }

        public async Task<Result<int>> CadastrarAsync(Usuario usuario)
        {
            var hash = _cryptographyProvider.HashPassword(usuario.Password, out var salt);
            usuario.PasswordHash = hash;
            usuario.PasswordSalt = salt;

            var result = await _usuarioRepository.CadastrarAsync(usuario);

            if (result <= 0)
                return Result<int>.Error("Erro ao cadastrar usuario");

            return Result<int>.Ok(result);
        }

        public async Task<Result<UsuarioTokenModel>> LoginAsync(Usuario usuario)
        {
            var result = await _usuarioRepository.GetUsuarioByUsernameAsync(usuario.Username);

            if (result is null)
                return Result<UsuarioTokenModel>.NotFoundResult();

            if (!_cryptographyProvider.VerifyPassword(usuario.Password, result.PasswordHash, result.PasswordSalt))
                return Result<UsuarioTokenModel>.Error("Senha inválida");

            return Result<UsuarioTokenModel>.Ok(_jwtProvider.Generate(result));
        }
    }
}
