namespace Confitec.Core.Application.Events.Dtos
{
    public class Request<TCommandOrQuery> where TCommandOrQuery : class
    {
        public TCommandOrQuery CommandOrQuery { get; set; }
    }
}
