namespace Confitec.Core.Domain.Entities
{
    public class Escolaridade : Entity
    {
        public string Descricao { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
