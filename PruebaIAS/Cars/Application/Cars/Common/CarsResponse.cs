using Domain.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Common
{
    public record CarsResponse(
    
        Guid idCarro,
        string Modelo,
        string Descripcion,
        decimal kilometraje,
        MarcaResponse Marca
        );

    public record MarcaResponse(
            int idMarca,
            string nombreMarca
        );

    
}
