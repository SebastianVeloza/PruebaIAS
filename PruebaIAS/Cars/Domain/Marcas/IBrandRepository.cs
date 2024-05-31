using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Marca
{
    public interface IBrandRepository
    {
        Task<List<Marc>> GetAllAsync();
        Task<Marc> GetByIdAsync(BrandId id);
        void Add(Marc marca);
        void Update(Marc marca);
        void Delete(BrandId id);
    }
}