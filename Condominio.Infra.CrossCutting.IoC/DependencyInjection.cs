using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Condominio.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection Teste(IServiceCollection service, IConfiguration configuration)
        {
            return service;
        }
    }
}
