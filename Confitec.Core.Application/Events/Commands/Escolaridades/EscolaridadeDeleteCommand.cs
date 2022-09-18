using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Application.Events.Dtos;
using MediatR;

namespace Confitec.Core.Application.Events.Commands.Escolaridades
{
    public class EscolaridadeDeleteCommand : BaseCommand, IBaseCommand, IRequest<Response>
    {
        public int Id { get; set; }

        public EscolaridadeDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
