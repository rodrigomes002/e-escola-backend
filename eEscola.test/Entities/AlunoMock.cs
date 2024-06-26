using eEscola.API.Models;

namespace eEscola.test.Entities;

public static class AlunoMock
{
    public static Aluno Aluno()
    {
        var aluno = new Aluno();
        aluno.Id = 1;
        aluno.Nome = "Calebe";
        aluno.CPF = 182736817263;

        return aluno;
    }

    public static Aluno? AlunoNull()
    {
        return null;
    }

    public static IEnumerable<Aluno> AlunoList()
    {
        return new List<Aluno>() {
            new Aluno()
            {
                Id = 1,
                Nome = "Calebe",
                CPF = 182736817263
            }
        };
    }

    public static IEnumerable<Aluno>? AlunoListNull()
    {
        return null;
    }
}
