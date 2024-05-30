using Domain.Cars;
using Infrastructure._Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Car car) => _context.Cars.Add(car);

        public async Task<List<Car>> GetAll()=> await _context.Cars.TellAsync();
    }
}
