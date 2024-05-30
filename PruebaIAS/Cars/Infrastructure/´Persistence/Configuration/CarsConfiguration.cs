using Domain.Cars;
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
            builder.HasKey(x => x.idCarro);

            builder.Property(x => x.idCarro).HasConversion(
                idcarro => idcarro.id,
                id => new CarsId(id));
            builder.Property(x => x.Modelo).HasMaxLength(30);
            builder.Property(x => x.Descripcion).HasMaxLength(100);
            builder.Property(x => x.Kilometraje).HasMaxLength(30);
            builder.OwnsOne(x => x.Marca, marca =>
            {
                marca.Property(c => c.idMarca).HasMaxLength(20).IsUnicode(true);
                marca.Property(c => c.NombreMarca);
            });
        }
    }
}
