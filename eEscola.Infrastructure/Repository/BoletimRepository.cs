using Dapper;
using eEscola.Domain.Entities;
using eEscola.Domain.Interfaces;
using Npgsql;

namespace eEscola.Infrastructure.Repository
{
    public class BoletimRepository : IBoletimRepository
    {
        private readonly IConnectionStringConfiguration _connectionStringConfiguration;

        public BoletimRepository(IConnectionStringConfiguration connectionStringConfiguration)
        {
            _connectionStringConfiguration = connectionStringConfiguration;
        }
        public async Task<IEnumerable<Boletim>> GetAll()
        {
            await using var conexao = new NpgsqlConnection(_connectionStringConfiguration.GetConnectionString());

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
