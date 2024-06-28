using eEscola.Domain.Entities.Enums;

namespace eEscola.Domain.Entities
{
    public class Boletim : Entity
    {
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public Bimestre Bimestre { get; set; }
        public double Nota { get; set; }
    }
}
