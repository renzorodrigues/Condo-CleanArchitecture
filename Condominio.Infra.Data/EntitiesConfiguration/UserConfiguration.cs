using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Condominio.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();

            builder.HasOne(p => p.Unit)
            .WithMany(b => b.Users)
            .HasForeignKey(p => p.UnitId);

            // builder.HasData(
            //     new User("Renzo", new Guid("d4da42ff-ec1c-4502-b1f3-0f8b25708cf3")),
            //     new User("Rodrigo", new Guid("f2262605-321c-4d7a-8b77-746e8d147797")),
            //     new User("Rodolfo", new Guid("1bfb510a-131d-41ed-b2c7-b609f212de9c"))
            // );
        }
    }
}
