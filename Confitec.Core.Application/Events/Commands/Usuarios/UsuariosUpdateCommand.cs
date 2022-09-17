using Confitec.Core.Application.Events.Commands.Base;

namespace Confitec.Core.Application.Events.Commands.Usuarios
{
    public class UsuariosUpdateCommand : UsuarioCommand, ICommand
    {
        public int Id { get; set; }
    }
}
