using Dapper;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;
using Npgsql;

namespace eEscola.Infrastructure.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IConnectionStringConfiguration _connectionStringConfiguration;
        
        public AlunoRepository(IConnectionStringConfiguration connectionStringConfiguration)
        {
            _connectionStringConfiguration = connectionStringConfiguration;
        }

        public async Task<bool> Add(Aluno aluno)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Nome = aluno.Nome,
                CPF = aluno.CPF
            };

            int result = await conexao.ExecuteAsync("INSERT INTO tb_aluno(nome,cpf) VALUES (@Nome,@CPF)", param);

            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            int result = await conexao.ExecuteAsync("DELETE FROM tb_aluno WHERE id=@Id", new { Id = id });

            return result > 0;
        }

        public async Task<bool> Edit(Aluno aluno)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                CPF = aluno.CPF
            };

            int result = await conexao.ExecuteAsync("UPDATE tb_aluno SET nome=@Nome, cpf=@CPF WHERE id=@Id", param);

            return result > 0;
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var aluno = await conexao.QueryAsync<Aluno>("SELECT id as Id, nome as Nome, cpf as CPF FROM tb_aluno");

            return aluno;
        }

        public async Task<Aluno> GetById(int id)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var aluno = await conexao.QueryFirstOrDefaultAsync<Aluno>("SELECT * FROM tb_aluno WHERE id=@id", new { Id = id });

            return aluno;
        }
    }
}
