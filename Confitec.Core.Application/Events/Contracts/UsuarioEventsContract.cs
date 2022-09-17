using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Contracts.Base;

namespace Confitec.Core.Application.Events.Contracts
{
    public class UsuarioEventsContract : IEventsContract<UsuarioDto>
    {
        public ICommand CreateCommand => Activator.CreateInstance<UsuariosCreateCommand>();

        public ICommand UpdateCommand => Activator.CreateInstance<UsuariosUpdateCommand>();

        public ICommand DeleteCommand => Activator.CreateInstance<UsuariosDeleteCommand>();
    }
}
