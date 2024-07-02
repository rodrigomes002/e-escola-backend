using eEscola.Domain.Entities.Base;
using Flunt.Validations;

namespace eEscola.Domain.Entities
{
    public class Disciplina : Entity
    {
        public string Nome { get; set; }

        public Disciplina() { }

        public Disciplina(string nome)
        {
            Nome = nome;

            AddNotifications(new Contract<Aluno>()
                .Requires()
                .IsNotNullOrWhiteSpace(Nome, nameof(Nome), $"O campo {nameof(Nome)} é obrigatório.")
                );
        }
    }
}
