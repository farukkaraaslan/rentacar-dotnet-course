using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Absract;
using Business.Constants;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;

namespace Business.Rules
{
    public class RentalBusinesRules
    {
        private readonly IRentalDal _rentalDal;
        public RentalBusinesRules(IRentalDal rentalDal)
        {
            _rentalDal=rentalDal;
        }

        public void CheckIfCarAvailable(CarState carState)
        {
            if (carState != CarState.Available)
            {
                throw new BusinessException(Messagess.Car.CarNotAvailable);
            }
        }
    }
}
