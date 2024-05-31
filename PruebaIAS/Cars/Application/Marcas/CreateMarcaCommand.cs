using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marca
{
    public record CreateBrandCommand(
      string NombreMarca
  ) : IRequest<ErrorOr<int>>;
}
