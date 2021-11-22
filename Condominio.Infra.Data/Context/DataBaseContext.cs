using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserType> ApplicationUsersTypes { get; set; }

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
