using Domain.Cars;
using Domain.Primitives;
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
    public sealed class CreateCarsCommandHandler : IRequestHandler<CreateCarsCommand, ErrorOr<Unit>>
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarsCommandHandler(ICarsRepository carsRepository, IUnitOfWork unitOfWork)
        {
            _carsRepository = carsRepository ?? throw new ArgumentNullException(nameof(carsRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCarsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(Marca.create(request.IdMarca,request.NombreMarca) is not Marca marca)
                {
                    //return Error.Validation("Cars.Marca", "Marca is not valid");
                    return Unit.Value;
                }

                var car = new Cars(
                     new CarsId(Guid.NewGuid()),
                     request.Modelo,
                     request.Descripcion,
                     request.Precio,
                     request.Kilometraje,
                     marca
                    );
                _carsRepository.Add(car);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
