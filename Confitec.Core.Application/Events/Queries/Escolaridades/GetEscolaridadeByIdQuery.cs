using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Queries.Escolaridades
{
    public class GetEscolaridadeByIdQuery : IRequest<Response<EscolaridadeModel>>
    {
        public int Id { get; set; }
    }
}
