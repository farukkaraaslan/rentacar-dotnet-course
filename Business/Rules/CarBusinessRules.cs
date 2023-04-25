using System;
using Business.Rules.Validation.FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Business.Constants;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using FluentValidation;

namespace Business.Rules
{
    
    public class CarBusinessRules
    {
        private readonly CarValidator _validator;
        private readonly ICarDal _carDal;

        public CarBusinessRules (ICarDal carDal, CarValidator validator)
        { 
            _carDal=carDal;
            _validator = validator;
        }
        public void CheckIfCarExistByPlate(string plate)
        {
            if (_carDal.Get(c=>c.Plate== plate) != null) 
            {
                throw new BusinessException(Messagess.Car.AllReadyExists);
            }
        }
        public void ValidateCar(Car car)
        {
            var result = _validator.Validate(car);
            if (!result.IsValid)
            {
                var errorMessages = string.Join(",", result.Errors.Select(e => $"[{e.PropertyName}: {e.ErrorMessage}]"));
                throw new ValidationException(errorMessages);
            }
        }

        public void CheckIfPlateIsValid(string plate)
        {
            string pattern = @"^(\d{2} [A-Z]{1,3} \d{2,4})$";

            var regex = Regex.IsMatch(plate, pattern);
            if (!regex)
            {
                throw new BusinessException(Messagess.Car.PlateIsValid);

            }
        }

        public void CheckIfCarExist(int id)
        {
            if (_carDal.Get(c => c.Id == id) == null)
            {
                throw new BusinessException(Messagess.Car.NotExists);
            }
        }
    }
}
