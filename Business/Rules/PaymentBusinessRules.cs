using Core.Exceptions;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Constants;
using Business.Rules.Validation.FluentValidation;
using DataAccess.Abstract;
using FluentValidation;

namespace Business.Rules
{
    public class PaymentBusinessRules
    {
        private readonly IPaymentDal _paymentDal;
        private readonly PaymentValidator _paymentValidator;
        private readonly PaymentDtoValidator _paymentDtoValidator;

        public PaymentBusinessRules(
            IPaymentDal paymentDal,
            PaymentValidator paymentValidator, 
            PaymentDtoValidator paymentDtoValidator
            )
        {
            _paymentDal = paymentDal;
            _paymentValidator = paymentValidator;
            _paymentDtoValidator=paymentDtoValidator;

        }
        public void CheckIfPaymentValid(PaymentDto paymentDto)
        {
            if (_paymentDal.Get(p =>
                    p.CardNumber == paymentDto.CardNumber &&
                    p.CardHolder == paymentDto.CardHolder &&
                    p.CardExpirationYear == paymentDto.CardExpirationYear &&
                    p.CardExpirationMonth == paymentDto.CardExpirationMonth &&
                    p.CardCvv == paymentDto.CardCvv
                ) == null)
            {
                throw new BusinessException(Messagess.Payment.NotAValidPayment);
            }
        }

        public void CheckIfBalanceEnough(double balance, double price)
        {
            if (balance- price < 0)
            {
                throw new BusinessException(Messagess.Payment.NotEnoughMoney);
            }
        }

        public void ValidatePayment(Payment payment)
        {
            var result = _paymentValidator.Validate(payment);
            if (!result.IsValid)
            {
                var errorMessages = string.Join(",", result.Errors.Select(e => $"[{e.PropertyName}: {e.ErrorMessage}]"));
                throw new ValidationException(errorMessages);
            }
        }

        public void CheckIfCadAllReadyExists(string cardNumber)
        {
            if (_paymentDal.Get(p=>p.CardNumber==cardNumber)!= null)
            {
             throw   new BusinessException(Messagess.Payment.NotAValidCard);
            }
        }
    }
}
