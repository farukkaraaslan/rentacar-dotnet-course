using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business.Absract
{
    public interface IRentalService
    {
        List<Rental> GetAll();
        Rental GetById(int id);
        Rental GetByCar(int carId);
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(int id);
    }
}
