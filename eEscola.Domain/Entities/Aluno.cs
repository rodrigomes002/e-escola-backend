namespace eEscola.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }

        public Aluno(string nome, long cpf)
        {
            Nome = nome;
            CPF = cpf;

            if (Nome is null)
                throw new ArgumentNullException("Nome deve ser preenchido!");
            if (CPF < 11)
                throw new ArgumentNullException("CPF incompleto!");
        }
    }
}
