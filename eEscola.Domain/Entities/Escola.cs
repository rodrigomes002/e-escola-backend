using eEscola.Domain.Entities.Base;
using Flunt.Validations;

namespace eEscola.Domain.Entities
{
    public class Escola : Entity
    {
        public string Nome { get; set; }
        public long CNPJ { get; set; }

        public Escola() { }

        public Escola(string nome, long cnpj)
        {
            Nome = nome;
            CNPJ = cnpj;

            AddNotifications(new Contract<Professor>()
                .Requires()
                .IsNotNullOrWhiteSpace(Nome, nameof(Nome), $"O campo {nameof(Nome)} é obrigatório.")
                );
        }
    }
}
