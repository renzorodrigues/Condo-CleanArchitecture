using Condominio.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(m => m.UserRoles)
                .WithOne(o => o.User)
                .HasForeignKey(f => f.UserId)
                .IsRequired();
        }
    }
}
