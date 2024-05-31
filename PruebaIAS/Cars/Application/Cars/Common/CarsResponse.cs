using Domain.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Common
{
    public record CarsResponse(
         Guid IdCarro,
         string Modelo,
         string Descripcion,
         decimal Precio,
         decimal Kilometraje,
         MarcaResponse Marca
     );

    public record MarcaResponse(
        int IdMarca,
        string NombreMarca
    );
}
