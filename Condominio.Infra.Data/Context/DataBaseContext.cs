using Condominio.Application.Interfaces.Data;
using Condominio.Domain.Entities;
using Condominio.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(DataBaseContext)
                    .Assembly);
        }
    }
}
