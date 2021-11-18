using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Condominio.Infra.Data.Context;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Repositories;
using FluentValidation;
using Condominio.Application.Mappings;
using MediatR;
using System;
using Condominio.Application.Products.Commands.Requests;
using Condominio.Application.Validations;
using Microsoft.OpenApi.Models;

namespace Condominio.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Condominio.Infra.Data")));

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Condominio.API", Version = "v1" });
            });

            // SERVICES

            // REPOSITORIES
            services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // VALIDATORS
            services.AddScoped<IValidator<CreateCondominiumCommand>, CondominiumValidator>();

            // AUTOMAPPER
            services.AddAutoMapper(typeof(MappingProfile));

            // MEDIATOR
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
