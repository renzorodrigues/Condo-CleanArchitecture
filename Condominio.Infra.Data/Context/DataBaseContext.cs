using Condominio.Domain.Entities;
using Condominio.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Condominio.Infra.Data.Context
{
    public class DataBaseContext : IdentityDbContext<
            AppUser,
            AppRole,
            Guid,
            IdentityUserClaim<Guid>,
            AppUserRole,
            IdentityUserLogin<Guid>,
            IdentityRoleClaim<Guid>,
            IdentityUserToken<Guid>
        >
    {
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Resident> Residents { get; set; }

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
