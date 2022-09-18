using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Infra.Data.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Infra.IoC.Configurations
{
    public static class RepositorysDI
    {
        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Usuario>, Repository<Usuario>>();
            services.AddTransient<IRepository<Escolaridade>, Repository<Escolaridade>>();
        }
    }
}
