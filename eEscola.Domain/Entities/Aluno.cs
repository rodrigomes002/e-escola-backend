using Flunt.Validations;

namespace eEscola.Domain.Entities
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public long CPF { get; set; }

        public Aluno() { }

        public Aluno(string nome, long cpf)
        {
            Nome = nome;
            CPF = cpf;

            AddNotifications(new Contract<Aluno>()
                .Requires()
                .IsNotNullOrWhiteSpace(Nome, nameof(Nome), $"O campo {nameof(Nome)} é obrigatório.")
                );
        }
    }
}
