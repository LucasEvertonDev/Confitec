using Confitec.Core.Model.Models.Base;

namespace Confitec.Core.Model.Models
{
    public class UsuarioModel : BaseModel
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int EscolaridadeId { get; set; }
    }
}
