using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Core.Application.Events.IoC.Base
{
    public abstract class BaseEventsDI
    {
        public void IncludeDependencys(IServiceCollection services)
        {
            AddCommandHandlers(services);
            AddQueryHandlers(services);
            AddEventsContract(services);
            AddValidatorCommands(services);
        }

        public abstract void AddCommandHandlers(IServiceCollection services);

        public abstract void AddQueryHandlers(IServiceCollection services);

        public abstract void AddValidatorCommands(IServiceCollection services);

        public abstract void AddEventsContract(IServiceCollection services);
    }
}
