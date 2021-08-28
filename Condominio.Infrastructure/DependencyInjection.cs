using Condominio.Application.Interfaces.Email;
using Condominio.Infrastructure.Data;
using Condominio.Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Condominio.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DataBaseConnection"));
            });
            
            services.AddScoped<DataBaseContext>(option => option.GetService<DataBaseContext>());
            //services.AddScoped<EmailSender>(option => option.GetService<EmailSender>());

            return services;
        }
    }
}