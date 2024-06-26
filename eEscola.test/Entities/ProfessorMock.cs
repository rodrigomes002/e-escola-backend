using eEscola.API.Models;

namespace eEscola.test.Entities
{
    public class ProfessorMock
    {
        public static Professor Professor()
        {
            var professor = new Professor();
            professor.Id = 1;
            professor.Nome = "Sr. Madruga";
            professor.CPF = 45678912303;

            return professor;
        }

        public static Professor? ProfessorNull()
        {
            return null;
        }

        public static IEnumerable<Professor> ProfessorList()
        {
            return new List<Professor>()
            {
                new Professor
                {
                    Id = 1,
                    Nome = "Guanabara",
                    CPF = 457891328516
                }
            };
        }

        public static IEnumerable<Professor>? ProfessorListNull()
        {
            return null;
        }
    }
}
