using Domain.Marca;
using Domain.Primitives;
using Domain.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cars
{
    public class Car : AgregateRoot
    {
        public Car() { } 

        public Car(CarsId idCarro, string modelo, string descripcion, decimal precio, decimal kilometraje, BrandId brandId)
        {
            if (idCarro == null) throw new ArgumentException("Car ID is required.", nameof(idCarro));
            if (string.IsNullOrWhiteSpace(modelo)) throw new ArgumentException("Model is required.", nameof(modelo));
            if (modelo.Length > 30) throw new ArgumentException("Model can't be longer than 30 characters.", nameof(modelo));
            if (precio <= 0) throw new ArgumentException("Price must be greater than zero.", nameof(precio));
            if (kilometraje < 0) throw new ArgumentException("Mileage must be non-negative.", nameof(kilometraje));
            if (brandId == null) throw new ArgumentException("Brand ID is required.", nameof(brandId));
            if (descripcion != null && descripcion.Length > 100) throw new ArgumentException("Description can't be longer than 100 characters.", nameof(descripcion));

            IdCarro = idCarro;
            Modelo = modelo;
            Descripcion = descripcion;
            Precio = precio;
            Kilometraje = kilometraje;
            BrandId = brandId;

            Raise(new CarCreatedEvent(idCarro.id));
        }

        public CarsId IdCarro { get; private set; }
        public string Modelo { get; private set; }
        public string Descripcion { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Kilometraje { get; private set; }
        public BrandId BrandId { get; private set; }

        public static Car UpdateCar(Guid idCarro, string modelo, string descripcion, decimal precio, decimal km, BrandId brandId)
        {
            return new Car(new CarsId(idCarro), modelo, descripcion, precio, km, brandId);
        }
    }

    public record CarCreatedEvent(Guid CarId) : DomainEvent(CarId);
}
