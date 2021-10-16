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

            builder.HasOne(p => p.Address)
            .WithOne(b => b.Condominium)
            .HasForeignKey<Address>(p => p.CondominiumId);

            // builder.HasData(
            //     new Condominium("Residencial Florença"),
            //     new Condominium("Condomínio Udi")
            // );
        }
    }
}
