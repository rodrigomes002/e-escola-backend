using eEscola.API.Models;

namespace eEscola.test.Entities
{
    public static class DisciplinaMock
    {
        public static Disciplina Disciplina()
        {
            var disciplina = new Disciplina();
            disciplina.Id = 1;
            disciplina.Nome = "Matemática";

            return disciplina;
        }

        public static Disciplina? DisciplinaNull()
        {
            return null;
        }

        public static IEnumerable<Disciplina> DisciplinaList()
        {
            return new List<Disciplina>()
            {
                new Disciplina()
                {
                    Id = 1,
                    Nome = "Matemática"
                }
            };
        }

        public static IEnumerable<Disciplina>? DisciplinaListNull()
        {
            return null;
        }
    }
}
