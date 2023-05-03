using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Constants;
using Business.Rules.Validation.FluentValidation;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using FluentValidation;

namespace Business.Rules
{
    public class RentalBusinessRules
    {
        private readonly IRentalDal _rentalDal;
        private readonly PaymentDtoValidator _paymentDtoValidator;
        public RentalBusinessRules(IRentalDal rentalDal, PaymentDtoValidator paymentDtoValidator)
        {
            _rentalDal=rentalDal;
            _paymentDtoValidator=paymentDtoValidator;
        }

        public void CheckIfCarAvailable(CarState carState)
        {
            if (carState != CarState.Available)
            {
                throw new BusinessException(Messagess.Car.CarNotAvailable);
            }
        }

        public void ValidatePaymentDto(PaymentDto paymentDto)
        {
            var result = _paymentDtoValidator.Validate(paymentDto);
            if (!result.IsValid)
            {
                var errorMessages = string.Join(",", result.Errors.Select(e => $"[{e.PropertyName}: {e.ErrorMessage}]"));
                throw new ValidationException(errorMessages);
            }
        }
    }
}
