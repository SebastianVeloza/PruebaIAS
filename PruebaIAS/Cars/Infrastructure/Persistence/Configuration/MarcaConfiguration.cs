using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Marca;

namespace Infrastructure.Persistence.Configuration
{
    internal class MarcaConfiguration : IEntityTypeConfiguration<Marc>
    {
        public void Configure(EntityTypeBuilder<Marc> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasConversion(id => id.id, id => new BrandId(id));

            builder.Property(x => x.Nombre)
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}