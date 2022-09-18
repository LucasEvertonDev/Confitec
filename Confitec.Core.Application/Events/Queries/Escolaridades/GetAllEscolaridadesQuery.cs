using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Queries.Escolaridades
{
    public class GetAllEscolaridadesQuery : IRequest<Response<IEnumerable<EscolaridadeModel>>>
    {
    }
}
