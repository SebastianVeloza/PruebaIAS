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
        public Car()
        {
        }

        public Car(CarsId idCarro, string modelo, string descripcion, decimal precio, decimal kilometraje, Marca marca)
        {
            this.idCarro = idCarro;
            Modelo = modelo;
            Descripcion = descripcion;
            Precio = precio;
            Kilometraje = kilometraje;
            Marca = marca;
        }

        public CarsId idCarro { get; private set; }
        public string Modelo { get; private set; }
        public string Descripcion { get; private set; }
        public decimal Precio { get; private set; }
        public Decimal Kilometraje { get; private set; }
        public Marca Marca { get; private set; }


        public static Car UpdateCars( Guid idCarro,
            string modelo, string descripcion, decimal precio, decimal km, Marca marca
            )
        {
            return new Car(new CarsId(idCarro), modelo, descripcion, precio, km, marca);
        }
    }
}
