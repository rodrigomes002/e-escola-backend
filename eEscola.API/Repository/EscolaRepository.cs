using Dapper;
using eEscola.API.Models;
using Npgsql;

namespace eEscola.API.Repository
{
    public class EscolaRepository : IEscolaRepository
    {
        public async Task<bool> Add(Escola escola)
        {
            await using var conexao = new NpgsqlConnection("Server=localhost;Port=5432;Database=eEscola;User Id=postgres;Password=#C4l3b3018;");

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
            await using var conexao = new NpgsqlConnection("Server=localhost;Port=5432;Database=eEscola;User Id=postgres;Password=#C4l3b3018;");

            int result = await conexao.ExecuteAsync("DELETE FROM tb_escola WHERE id=@Id", new { Id = id });

            return result > 0;
        }

        public async Task<bool> Edit(Escola escola)
        {
            await using var conexao = new NpgsqlConnection("Server=localhost;Port=5432;Database=eEscola;User Id=postgres;Password=#C4l3b3018;");

            var param = new
            {
                Id = escola.Id,
                Nome = escola.Nome,
                CNPJ = escola.CNPJ                
            };

            int result = await conexao.ExecuteAsync("UPDATE tb_escola SET nome=@Nome, cnpj=@CNPJ WHERE id=@Id", param);

            return result > 0;
        }

        public async Task<List<Escola>> GetAll()
        {
            await using var conexao = new NpgsqlConnection("Server=localhost;Port=5432;Database=eEscola;User Id=postgres;Password=#C4l3b3018;");

            var escola = await conexao.QueryAsync<Escola>("SELECT * FROM tb_escola");

            return escola.ToList();
        }

        public async Task<Escola> GetById(int id)
        {
            await using var conexao = new NpgsqlConnection("Server=localhost;Port=5432;Database=eEscola;User Id=postgres;Password=#C4l3b3018;");

            var escola = await conexao.QueryFirstOrDefaultAsync<Escola>("SELECT * FROM tb_escola WHERE id=@Id", new { Id = id });

            return escola;
        }

    }
}
