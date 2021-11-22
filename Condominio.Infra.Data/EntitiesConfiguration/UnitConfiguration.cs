using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasIndex(i => new { i.Code, i.BlockId })
                .IsUnique();

            builder.Property(p => p.Code)
                .IsRequired();

            builder.Property(p => p.Size)
                .IsRequired();

            builder.HasOne(p => p.Block)
                .WithMany(b => b.Units)
                .HasForeignKey(p => p.BlockId);
        }
    }
}
