using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Marca
{

    public class Marc : AgregateRoot
    {
        public Marc() { }

        public Marc(BrandId id, string nombre)
        {
            if (id == null) throw new ArgumentException("Brand ID is required.", nameof(id));
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Name is required.", nameof(nombre));
            if (nombre.Length > 20) throw new ArgumentException("Name can't be longer than 20 characters.", nameof(nombre));

            Id = id;
            Nombre = nombre;


            Raise(new BrandCreatedEvent(id.id));
        }

        public BrandId Id { get; private set; }
        public string Nombre { get; private set; }


    }


    public record BrandCreatedEvent(Guid BrandId) : DomainEvent(BrandId);
}
