using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Events.Queries.Usuarios;
using Confitec.Core.Model.Models;

namespace Confitec.Core.Application.Events.Contracts
{
    public class UsuarioEventsContract : IEventsContract<UsuarioModel>
    {
        public Type CreateCommand => typeof(UsuariosCreateCommand);

        public Type UpdateCommand => typeof(UsuariosUpdateCommand);

        public Type DeleteCommand => typeof(UsuariosDeleteCommand);

        public Type GetAllQuery => typeof(GetAllUsuariosQuery);

        public Type GetByIdQuery => typeof(GetUsuarioByIdQuery);
    }
}
