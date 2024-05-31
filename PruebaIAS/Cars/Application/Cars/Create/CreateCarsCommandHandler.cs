using Domain.Cars;
using Domain.Marca;
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
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarsCommandHandler(ICarsRepository carsRepository, IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _carsRepository = carsRepository ?? throw new ArgumentNullException(nameof(carsRepository));
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCarsCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(new BrandId(request.IdMarca));
            if (brand is null)
            {
                return Error.Validation("Brand", "Marca no encontrada");
            }

            var car = new Car(
                new CarsId(Guid.NewGuid()),
                request.Modelo,
                request.Descripcion,
                request.Precio,
                request.Kilometraje,
                brand
            );

            _carsRepository.Add(car);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}