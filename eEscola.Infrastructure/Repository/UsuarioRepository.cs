using Dapper;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;
using Npgsql;

namespace eEscola.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionStringConfiguration _connectionStringConfiguration;

        public UsuarioRepository(IConnectionStringConfiguration connectionStringConfiguration)
        {
            _connectionStringConfiguration = connectionStringConfiguration;
        }

        public async Task<int> CadastrarAsync(Usuario usuario)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Username = usuario.Username,
                Password = usuario.Password,
                PasswordHash = usuario.PasswordHash,
                PasswordSalt = usuario.PasswordSalt
            };

            var result = await conexao.ExecuteAsync("INSERT INTO tb_usuario(username,password,password_hash,password_salt)" +
                                                    " VALUES (@Username,@Password,@PasswordHash,@PasswordSalt)", param);

            

            return result;
        }

        public async Task<Usuario> GetUsuarioByUsernameAsync(string username)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                username = username
            };

            var result = await conexao.QueryFirstOrDefaultAsync<Usuario>("SELECT id AS Id, username AS Username, " +
                                                                "password AS Password, password_hash AS PasswordHash, " +
                                                                "password_salt AS PasswordSalt " +
                                                                "FROM tb_usuario WHERE username = @Username", param);

            return result;
        }
    }
}
