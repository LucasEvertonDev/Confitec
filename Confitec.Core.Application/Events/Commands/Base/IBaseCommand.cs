using MediatR;

namespace Confitec.Core.Application.Events.Commands.Base
{
    public interface IBaseCommand
    {
        void ValidateCommand<TCommand>();
    }
}