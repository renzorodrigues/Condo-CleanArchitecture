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
using Condominio.Service.EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Condominio.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;

namespace Condominio.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentityCore<AppUser>(option =>
                {
                    option.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<DataBaseContext>();

            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Condominio.Infra.Data")));

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                 });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Condominio.API", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("TokenKey").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // SERVICES
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<INotificationService, NotificationService>();

            // REPOSITORIES
            services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            services.AddScoped<IUnitUserRepository, UnitUserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();

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
