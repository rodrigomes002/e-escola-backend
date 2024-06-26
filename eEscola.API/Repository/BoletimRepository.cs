using Dapper;
using eEscola.API.Interfaces;
using eEscola.API.Models;
using Npgsql;

namespace eEscola.API.Repository
{
    public class BoletimRepository : IBoletimRepository
    {
        public async Task<IEnumerable<Boletim>> GetAll()
        {
            await using var conexao = new NpgsqlConnection("Server=localhost;Port=5432;Database=eEscola;User Id=postgres;Password=#C4l3b3018;");

            var boletim = await conexao.QueryAsync<Boletim, Aluno, Disciplina, Boletim>("SELECT * FROM tb_boletim as B " +
                                                            "INNER JOIN tb_aluno as A ON A.id = B.id_aluno " +
                                                            "INNER JOIN tb_disciplina as D ON D.id = B.id_disciplina "
                                                            , map: (boletim, aluno, disciplina) =>
                                                            {
                                                                boletim.Aluno = aluno;
                                                                boletim.Disciplina = disciplina;
                                                                return boletim;
                                                            },
                                                                splitOn: "Id, Id, Id");

            return boletim;
        }
    }
}
