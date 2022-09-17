using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Events.Commands.Base;
using Confitec.Core.Domain.Interfaces;

namespace Confitec.Core.Application.Events.Contracts.Base
{
    public interface IEventsContract<TDto> where TDto : IDtoBase
    {
        public ICommand CreateCommand { get; }

        public ICommand UpdateCommand { get; }

        public ICommand DeleteCommand { get; }
    }
}
