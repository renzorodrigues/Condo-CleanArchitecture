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

            builder.HasIndex(i => i.CredentialId)
                .IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(o => o.ApplicationUserType)
                .WithMany(m => m.ApplicationUsers)
                .HasForeignKey(f => f.ApplicationUserTypeCode);

            builder.HasOne(o => o.Credential)
                .WithMany(m => m.ApplicationUsers)
                .HasForeignKey(f => f.CredentialId);
        }
    }
}
