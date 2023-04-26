using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Absract;
using Business.Constants;
using Business.Rules;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
{
    public class RentalManager :IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarService _carService;
        private readonly RentalBusinesRules _rentalBusinesRules;
        public RentalManager(IRentalDal rentalDal,ICarService carService, RentalBusinesRules rentalBusinesRules)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _rentalBusinesRules = rentalBusinesRules;
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
            _rentalBusinesRules.CheckIfCarAvailable(_carService.GetById(rental.CarId).State);
           
            rental.TotalPrice = rental.RentedForDays * rental.DailyPrice;
            rental.RentalStartDate = DateTime.Now;
            rental.RentalEndDate = null;
            _rentalDal.Add(rental);
            _carService.ChanceState(rental.CarId, CarState.Rented);
            
           
        }

        public void Update(Rental rental)
        {
           _rentalDal.Update(rental);
        }

        public void Delete(int id)
        {
            var rental = GetById(id);
            _carService.ChanceState(rental.CarId, CarState.Available);
            _rentalDal.Delete(id);
            
        }
    }
}
