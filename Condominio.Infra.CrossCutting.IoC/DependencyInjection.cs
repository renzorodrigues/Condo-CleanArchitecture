using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Condominio.Infra.Data.Context;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Repositories;
using Condominio.Application.Interfaces.Services;
using FluentValidation;
using Condominio.Application.Mappings;
using MediatR;
using Condominio.Application.Services;
using System;
using Condominio.Application.Products.Commands.Requests;
using Condominio.Application.Validations;

namespace Condominio.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Condominio.Infra.Data")));

            // SERVICES
            services.AddScoped<ICondominiumService, CondominiumService>();
            services.AddScoped<IUserService, UserService>();

            // REPOSITORIES
            services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            // VALIDATORS
            services.AddScoped<IValidator<CreateCondominiumRequest>, CondominiumValidator>();

            // AUTOMAPPER
            services.AddAutoMapper(typeof(MappingProfile));

            // MEDIATOR
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
