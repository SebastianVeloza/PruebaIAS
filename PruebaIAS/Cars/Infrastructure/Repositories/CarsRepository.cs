using Domain.Cars;
using Infrastructure._Persistence;
using Microsoft.EntityFrameworkCore;
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

        public void Add(Car car) => _context.Carss.Add(car);

        public async Task<List<Car>> GetAllAsync() => await _context.Carss.ToListAsync();

        public async Task<Car> GetByIdAsync(CarsId idCarro) => await _context.Carss.FindAsync(idCarro);

        public void Update(Car car) => _context.Carss.Update(car);

        public void Delete(CarsId idCarro)
        {
            var car = _context.Carss.Find(idCarro);
            if (car != null)
            {
                _context.Carss.Remove(car);
            }
        }

        public Task<List<Car>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}