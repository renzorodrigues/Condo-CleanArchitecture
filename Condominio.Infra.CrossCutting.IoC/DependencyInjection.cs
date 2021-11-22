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
using Condominio.Application.Products.Commands.Condominium;
using Condominio.Application.Validations;
using Microsoft.OpenApi.Models;
using Condominio.Application.Interfaces.Services;
using Condominio.Service.AuthService;
using Condominio.Application.Products.Commands.Credential;
using Condominio.Service.EmailService;

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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<INotificationService, NotificationService>();

            // REPOSITORIES
            services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            services.AddScoped<ICredentialRepository, CredentialRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            // VALIDATORS
            services.AddScoped<IValidator<CreateCondominiumCommand>, CondominiumValidator>();
            services.AddScoped<IValidator<CreateCredentialCommand>, AccountValidator>();

            // AUTOMAPPER
            services.AddAutoMapper(typeof(MappingProfile));

            // MEDIATOR
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
