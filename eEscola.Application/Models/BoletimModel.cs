using eEscola.Domain.Entities.Enums;

namespace eEscola.Application.Models
{
    public class BoletimModel
    {
        public int Id { get; set; }
        public AlunoModel Aluno { get; set; }
        public DisciplinaModel Disciplina { get; set; }
        public Bimestre Bimestre { get; set; }
        public double Nota { get; set; }
    }
}
