using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Queries
{
    public class GetAllUsuariosQuery : IRequest<Response<IEnumerable<UsuarioModel>>>
    {
    }
}
