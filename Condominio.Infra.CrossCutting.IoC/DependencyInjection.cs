using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Condominio.Infra.Data.Context;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Repositories;
using Condominio.Application.Interfaces.Services;
using Condominio.Application;
using FluentValidation;
using Condominio.Domain.Entities;
using Condominio.Domain.Validations;

namespace Condominio.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Condominio.API")));

            // SERVICES
            services.AddScoped<ICondominiumService, CondominiumService>();
            services.AddScoped<IUserService, UserService>();

            // REPOSITORIES
            services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            // VALIDATORS
            services.AddScoped<IValidator<Condominium>, CondominiumValidator>();

            return services;
        }
    }
}
