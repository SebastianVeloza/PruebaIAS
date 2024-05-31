using Domain.Cars;
using Domain.ValueObjets;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Create
{
    public record CreateCarsCommand(
     string Modelo,
     string Descripcion,
     decimal Precio,
     decimal Kilometraje,
     int IdMarca
 ) : IRequest<ErrorOr<Unit>>;
}