using Domain.Marca;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marca
{
    public sealed class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ErrorOr<int>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<int>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Marc(request.NombreMarca);
            _brandRepository.Add(brand);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return brand.Id;
        }
    }
}