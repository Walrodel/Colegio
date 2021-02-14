using Colegio.Core.Entities;
using Colegio.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Colegio.Infrastructure.Data.Configurations
{
    public class SeguridadConfiguration : IEntityTypeConfiguration<Seguridad>
    {
        public void Configure(EntityTypeBuilder<Seguridad> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdSeguridad");

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.NombreUsuario)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Contrasena)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Rol)
                .HasMaxLength(15)
                .IsRequired()
                .HasConversion(
                    x => x.ToString(),
                    x => (TipoRol)Enum.Parse(typeof(TipoRol), x)
                    );

        }
    }
}
