using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Infra.Utils.Utils
{
    public static class EngineContext
    {
        private static IServiceProvider _serviceProvider { get; set; }

        public static void AddServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static TService GetService<TService>()
        {
            return _serviceProvider.GetService<TService>();
        }

        public static object? GetService(Type t)
        {
            try
            {
                return _serviceProvider.GetService(t);
            }
            catch
            {
                return null;
            }
        }
    }
}