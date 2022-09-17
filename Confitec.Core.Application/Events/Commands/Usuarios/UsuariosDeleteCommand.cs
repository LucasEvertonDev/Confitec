using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Commands.Usuarios
{
    public class UsuariosDeleteCommand : Command, ICommand, IRequest<Response>
    {
        public int Id { get; set; }

        public UsuariosDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
