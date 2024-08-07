﻿using Dapper;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;
using Npgsql;

namespace eEscola.Infrastructure.Repository
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly IConnectionStringConfiguration _connectionStringConfiguration;

        public EscolaRepository(IConnectionStringConfiguration connectionStringConfiguration)
        {
            _connectionStringConfiguration = connectionStringConfiguration;
        }
        public async Task<bool> Add(Escola escola)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Nome = escola.Nome,
                CNPJ = escola.CNPJ
            };

            int result = await conexao.ExecuteAsync("INSERT INTO tb_escola(nome,cnpj) VALUES (@Nome,@CNPJ)", param);

            return result > 0;  
        }

        public async Task<bool> Delete(int id)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            int result = await conexao.ExecuteAsync("DELETE FROM tb_escola WHERE id=@Id", new { Id = id });

            return result > 0;
        }

        public async Task<bool> Edit(Escola escola)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var param = new
            {
                Id = escola.Id,
                Nome = escola.Nome,
                CNPJ = escola.CNPJ                
            };

            int result = await conexao.ExecuteAsync("UPDATE tb_escola SET nome=@Nome, cnpj=@CNPJ WHERE id=@Id", param);

            return result > 0;
        }

        public async Task<IEnumerable<Escola>> GetAll()
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var escola = await conexao.QueryAsync<Escola>("SELECT * FROM tb_escola");

            return escola;
        }

        public async Task<Escola> GetById(int id)
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

            var escola = await conexao.QueryFirstOrDefaultAsync<Escola>("SELECT * FROM tb_escola WHERE id=@Id", new { Id = id });

            return escola;
        }
    }
}