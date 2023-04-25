using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Absract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
{
    public class RentalManager :IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal=rentalDal;
        }
        public List<Rental> GetAll()
        {
           return  _rentalDal.GetAll();
        }

        public Rental GetById(int id)
        {
            return _rentalDal.Get(r => r.Id == id);
        }

        public Rental GetByCar(int carId)
        {
            return _rentalDal.Get(r => r.CarId == carId);
        }

        public void Add(Rental rental)
        {
            _rentalDal.Add(rental);
        }

        public void Update(Rental rental)
        {
           _rentalDal.Update(rental);
        }

        public void Delete(int id)
        {
            _rentalDal.Delete(id);
        }
    }
}
