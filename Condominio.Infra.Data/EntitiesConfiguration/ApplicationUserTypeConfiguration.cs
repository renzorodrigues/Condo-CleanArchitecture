using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class ApplicationUserTypeConfiguration : IEntityTypeConfiguration<ApplicationUserType>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserType> builder)
        {
            builder.HasKey(k => k.Code);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
