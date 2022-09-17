namespace Confitec.Core.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get;set; }

        public int EscolaridadeId { get; set; } 

        public Escolaridade Escolaridade { get; set; }

        public int HistoricoEscolarId { get; set; }
    }
}
