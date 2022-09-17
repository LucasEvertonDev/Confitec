using MediatR;

namespace Confitec.Core.Application.Events.Dtos
{
    public class Request<TCommandOrQuery> : IRequest<TCommandOrQuery> where TCommandOrQuery : class
    {
        public TCommandOrQuery CommandOrQuery { get; set; }
    }
}
