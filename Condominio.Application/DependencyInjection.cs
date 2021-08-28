using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Condominio.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection service, IConfiguration configuration)
        {
            return service;
        }
    }
}