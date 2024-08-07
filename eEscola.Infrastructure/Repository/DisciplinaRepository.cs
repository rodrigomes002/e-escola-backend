﻿using Dapper;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;
using Npgsql;

namespace eEscola.Infrastructure.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly IConnectionStringConfiguration _connectionStringConfiguration;

        public DisciplinaRepository(IConnectionStringConfiguration connectionStringConfiguration)
        {
            _connectionStringConfiguration = connectionStringConfiguration;
        }
        public async Task<bool> Add(Disciplina disciplina)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Nome = disciplina.Nome
            };

            int result = await conexao.ExecuteAsync("INSERT INTO tb_disciplina(nome) VALUES(@Nome)", param);

            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            int result = await conexao.ExecuteAsync("DELETE FROM tb_disciplina WHERE id=@Id", new { Id = id });

            return result > 0;
        }

        public async Task<bool> Edit(Disciplina disciplina)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Id = disciplina.Id,
                Nome = disciplina.Nome
            };

            int result = await conexao.ExecuteAsync("UPDATE tb_disciplina SET nome=@Nome WHERE id=@Id", param);

            return result > 0;
        }

        public async Task<IEnumerable<Disciplina>> GetAll()
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var disciplina = await conexao.QueryAsync<Disciplina>("SELECT * FROM tb_disciplina");

            return disciplina;
        }

        public async Task<Disciplina> GetById(int id)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var disciplina = await conexao.QueryFirstOrDefaultAsync<Disciplina>("SELECT * FROM tb_disciplina WHERE id=@Id", new { Id = id } );

            return disciplina;
        }
    }
}
