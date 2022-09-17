using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Events.Commands.Base;
using MediatR;

namespace Confitec.Core.Application.Events.Commands.Usuarios
{
    public class UsuariosDeleteCommand : ICommand, IRequest<UsuarioDto>
    {
        public int Id { get; set; }

        public UsuariosDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
