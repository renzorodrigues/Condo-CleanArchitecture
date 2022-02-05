using Condominio.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(m => m.UserRoles)
                .WithOne(o => o.Role)
                .HasForeignKey(f => f.RoleId)
                .IsRequired();
        }
    }
}
