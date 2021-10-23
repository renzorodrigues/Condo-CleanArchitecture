using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class CondominiumConfiguration : IEntityTypeConfiguration<Condominium>
    {
        public void Configure(EntityTypeBuilder<Condominium> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired();

            builder.OwnsOne(x => x.Address);
        }
    }
}
