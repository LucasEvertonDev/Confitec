using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Commands.Escolaridades
{
    public abstract class EscolaridadeCommand : BaseCommand, IRequest<Response<EscolaridadeModel>>, IBaseCommand
    {
        public string Descricao { get; set; }
    }
}
