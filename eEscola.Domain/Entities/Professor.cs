using eEscola.Domain.Entities.Base;
using Flunt.Validations;

namespace eEscola.Domain.Entities
{
    public class Professor : Entity
    {
        public string Nome { get; set; }
        public long CPF { get; set; }

        public Professor() { }

        public Professor(string nome, long cpf)
        {
            Nome = nome;
            CPF = cpf;

            AddNotifications(new Contract<Professor>()
                .Requires()
                .IsNotNullOrWhiteSpace(Nome, nameof(Nome), $"O campo {nameof(Nome)} é obrigatório.")
                );
        }
    }
}
