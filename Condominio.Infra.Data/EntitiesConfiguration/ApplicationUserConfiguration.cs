using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasIndex(i => i.Email)
                .IsUnique();

            builder.Property(p => p.Name)
                .HasMaxLength(200);

            builder.HasOne(o => o.ApplicationUserType)
                .WithMany(m => m.ApplicationUsers)
                .HasForeignKey(f => f.ApplicationUserTypeCode);

            builder.OwnsOne(o => o.Credential);
        }
    }
}
