namespace Confitec.Core.Application.Events.Dtos
{
    public interface IRequestH<TCommandOrQuery>
    {
        public TCommandOrQuery CommandOrQuery { get; set; }
    }
}
