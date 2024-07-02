using eEscola.Domain.Entities.Base;

namespace eEscola.Domain.Entities
{
    public class Escola : Entity
    {
        public string Nome { get; set; }
        public long CNPJ { get; set; }
    }
}
