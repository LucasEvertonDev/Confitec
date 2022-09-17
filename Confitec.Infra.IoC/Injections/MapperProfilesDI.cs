using AutoMapper;
using Confitec.Core.Application.Mappings;
using Confitec.Infra.Utils.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Infra.IoC.Injections
{
    public static class MapperProfilesDI
    {
        public static void AddMapperProfiles(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(App.Init<UsuariosMapperProfile>());
                mc.AddProfile(App.Init<EscolaridadeMapperProfile>());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
