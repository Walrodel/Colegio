using Colegio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Infrastructure.Data.Configurations
{
    public class IngresoConfiguration : IEntityTypeConfiguration<Ingreso>
    {
        public void Configure(EntityTypeBuilder<Ingreso> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IngresoId");

            builder.Property(e => e.Apellido).HasMaxLength(20);

            builder.Property(e => e.Casa).HasMaxLength(15);

            builder.Property(e => e.Edad).HasMaxLength(2);

            builder.Property(e => e.Identificacion).HasMaxLength(10);

            builder.Property(e => e.Nombre).HasMaxLength(20);
        }
    }
}
