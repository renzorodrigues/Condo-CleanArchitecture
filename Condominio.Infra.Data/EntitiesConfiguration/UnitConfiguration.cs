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
            builder.Property(p => p.Number).IsRequired();

            builder.HasOne(p => p.Block)
            .WithMany(b => b.Units)
            .HasForeignKey(p => p.BlockId);

            // builder.HasData(
            //     new Unit(903, 80),
            //     new Unit(904, 100.5)
            // );
        }
    }
}
