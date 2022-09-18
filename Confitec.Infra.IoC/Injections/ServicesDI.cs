using Confitec.Core.Application.Services;
using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Model.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Infra.IoC.Configurations
{
    public static class ServicesInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService<UsuarioModel>, UsuarioService>();
            services.AddScoped<IEscolaridadeService<EscolaridadeModel>, EscolaridadeService>();
        }
    }
}
