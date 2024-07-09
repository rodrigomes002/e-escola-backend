using Dapper;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;
using Npgsql;

namespace eEscola.Infrastructure.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IConnectionStringConfiguration _connectionStringConfiguration;

        public ProfessorRepository(IConnectionStringConfiguration connectionStringConfiguration)
        {
            _connectionStringConfiguration = connectionStringConfiguration;
        }

        public async Task<bool> Add(Professor professor)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Nome = professor.Nome,
                CPF = professor.CPF
            };

            int result = await conexao.ExecuteAsync("INSERT INTO tb_professor (nome,cpf) VALUES (@Nome,@CPF)", param);

            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            int result = await conexao.ExecuteAsync("DELETE FROM tb_professor WHERE id=@Id", new { Id = id });

            return result > 0;
        }

        public async Task<bool> Edit(Professor professor)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Id = professor.Id,
                Nome = professor.Nome,
                CPF = professor.CPF
            };

            int result = await conexao.ExecuteAsync("UPDATE tb_professor SET nome=@Nome, cpf=@CPF WHERE id=@Id", param);

            return result > 0;
        }

        public async Task<IEnumerable<Professor>> GetAll()
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var professor = await conexao.QueryAsync<Professor>("SELECT * FROM tb_professor");

            return professor;
        }

        public async Task<Professor> GetById(int id)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var professor = await conexao.QueryFirstOrDefaultAsync<Professor>("SELECT * FROM tb_professor WHERE id=@Id", new { Id = id });

            return professor;
        }
    }
}
