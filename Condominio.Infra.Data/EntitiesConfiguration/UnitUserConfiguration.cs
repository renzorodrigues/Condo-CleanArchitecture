using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class UnitUserConfiguration : IEntityTypeConfiguration<UnitUser>
    {
        public void Configure(EntityTypeBuilder<UnitUser> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(p => p.Unit)
                .WithMany(b => b.UnitUsers)
                .HasForeignKey(p => p.UnitId);

            builder.OwnsMany(o => o.Telphone);
        }
    }
}
