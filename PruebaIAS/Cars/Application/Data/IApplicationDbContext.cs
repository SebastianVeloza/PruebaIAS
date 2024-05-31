using Domain.Cars;
using Domain.Marca;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Car> Carss { get; set; }
        DbSet<Marc> Brands { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}