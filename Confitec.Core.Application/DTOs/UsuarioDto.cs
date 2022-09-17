namespace Confitec.Core.Application.DTOs
{
    public class UsuarioDto : DtoBase
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int EscolaridadeId { get; set; }

        public int HistoricoEscolarId { get; set; }
    }
}
