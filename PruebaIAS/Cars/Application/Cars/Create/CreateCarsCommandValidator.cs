using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Create
{
    public class CreateCarsCommandValidator: AbstractValidator<CreateCarsCommand>
    {
        public CreateCarsCommandValidator() {

            RuleFor(r => r.Modelo).NotEmpty().MaximumLength(30);
            RuleFor(r => r.Descripcion).NotEmpty().MaximumLength(100);
            RuleFor(r => r.Precio).NotEmpty();
            RuleFor(r => r.Kilometraje).NotEmpty();
            RuleFor(r => r.IdMarca).NotEmpty();
            RuleFor(r => r.NombreMarca).NotEmpty().MaximumLength(20);

        }
    }
}
