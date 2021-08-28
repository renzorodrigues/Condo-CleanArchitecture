using Condominio.Application.Interfaces.Data;
using Condominio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infrastructure.Data
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DbSet<Unit> Unit { get; set; }
    }
}