using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Rules;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using Microsoft.AspNetCore.Http.Features;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService

    {
        private readonly IPaymentDal _paymentDal;
        private readonly PaymentBusinessRules _paymentBusinessRules;

        public PaymentManager(IPaymentDal paymentDal, PaymentBusinessRules paymentBusinessRules)
        {
            _paymentDal=paymentDal;
            _paymentBusinessRules=paymentBusinessRules;
        }
        public List<Payment> GetAll()
        {
           return _paymentDal.GetAll();
        }

        public Payment GetById(int id)
        {
            return _paymentDal.Get(p=>p.Id==id);
        }

        public void Add(Payment payment)
        {
            _paymentBusinessRules.CheckIfCadAllReadyExists(payment.CardNumber);
            _paymentBusinessRules.ValidatePayment(payment);
            _paymentDal.Add(payment);
        }

        public void Update(Payment payment)
        {
            _paymentDal.Update(payment);
        }

        public void Delete(int id)
        {
            _paymentDal.Delete(id);
        }

        public void ProcessPayment(PaymentDto paymentDto)
        {
            _paymentBusinessRules.CheckIfPaymentValid(paymentDto);
            var payment = _paymentDal.Get(p => p.CardNumber == paymentDto.CardNumber);
            _paymentBusinessRules.CheckIfBalanceEnough(payment.Balance,paymentDto.Price);
            payment.Balance = payment.Balance - paymentDto.Price;
            Update(payment);

        }

     
    }
}
