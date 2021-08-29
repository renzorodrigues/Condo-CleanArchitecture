using Condominio.Application.Interfaces.Data;
using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DbSet<Unit> Units { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof (DataBaseContext)
                    .Assembly);
        }
    }
}
