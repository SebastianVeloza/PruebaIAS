using Domain.Marca;
using Infrastructure._Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MarcaRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public MarcaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Marc marca) => _context.Marca.Add(marca);

        public async Task<List<Marc>> GetAllAsync() => await _context.Marcas.ToListAsync();

        public async Task<Marc> GetByIdAsync(BrandId id) => await _context.Marcas.FindAsync(id);

        public void Update(Marc marca) => _context.Marcas.Update(marca);

        public void Delete(BrandId id)
        {
            var marca = _context.Marcas.Find(id);
            if (marca != null)
            {
                _context.Marcas.Remove(marca);
            }
        }
    }
}