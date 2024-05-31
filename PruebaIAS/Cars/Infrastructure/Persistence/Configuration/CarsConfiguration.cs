using Domain.Cars;
using Domain.Marca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure._Persistence.Configuration
{
    internal class CarsConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.IdCarro);

            builder.Property(x => x.IdCarro)
                   .HasConversion(idCarro => idCarro.id, id => new CarsId(id));

            builder.Property(x => x.Modelo)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.Descripcion)
                   .HasMaxLength(100);

            builder.Property(x => x.Precio)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Kilometraje)
                   .IsRequired();

            builder.HasOne<Marc>()
                   .WithMany()
                   .HasForeignKey(x => x.BrandId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}