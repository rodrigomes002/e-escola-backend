using eEscola.API.Models.Enums;

namespace eEscola.API.Models
{
    public class Boletim
    {
        public int Id { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public Bimestre Bimestre { get; set; }
        public double Nota { get; set; }
    }
}
