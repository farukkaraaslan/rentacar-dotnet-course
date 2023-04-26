using Core.Exceptions;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class PaymentBusinessRules
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentBusinessRules(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
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
                throw new BusinessException("NOT_A_VALID_PAYMENT");
            }
        }

        public void CheckIfBalanceEnough(double balance, double price)
        {
            if (balance- price < 0)
            {
                throw new BusinessException("NOT_ENOUGH_MONEY");
            }
        }
    }
}
