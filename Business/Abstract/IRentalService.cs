using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IRentalService
    {
        List<Rental> GetAll();
        Rental GetById(int id);
        Rental GetByCar(int carId);
        void Add(RentalDto rentalDto);
        void Update(Rental rental);
        void Delete(int id);
    }
}
