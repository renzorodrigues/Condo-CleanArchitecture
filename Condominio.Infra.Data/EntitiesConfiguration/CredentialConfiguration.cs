using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class CredentialConfiguration : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasIndex(i => i.Email)
                .IsUnique();

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
