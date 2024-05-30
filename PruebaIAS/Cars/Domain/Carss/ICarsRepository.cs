using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cars
{
    public interface ICarsRepository
    {
        Task<List<Car>> GetAll();
        void Add(Car car); 
    }
}
