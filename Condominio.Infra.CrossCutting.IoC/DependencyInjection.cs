using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Condominio.Infra.Data.Context;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Repositories;
using Condominio.Application.Interfaces.Services;
using Condominio.Application;

namespace Condominio.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Condominio.API")));

            services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            services.AddScoped<ICondominiumService, CondominiumService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
