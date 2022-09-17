using Confitec.Core.Application.Events.IoC;
using Confitec.Infra.Utils.Utils;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Infra.IoC.Injections
{
    public static class EventsDI
    {
        public static void AddEvents(this IServiceCollection services)
        {
            App.Init<UsuarioEventsDI>().IncludeDependencys(services);
            services.AddMediatR(AppDomain.CurrentDomain.Load("Confitec.Core.Application"));
        }
    }
}
