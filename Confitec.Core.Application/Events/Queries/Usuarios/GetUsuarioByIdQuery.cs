using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Queries.Usuarios
{
    public class GetUsuarioByIdQuery : IRequest<Response<UsuarioModel>>
    {
        public int Id { get; set; }
    }
}
