using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Dto;

namespace Business.Absract
{
    public interface IPaymentService
    {
        List<Payment> GetAll();
        Payment GetById(int id);
        void Add(Payment payment);
        void Update(Payment payment);
        void Delete(int id);
        void ProcessPayment (PaymentDto paymentDto);  
    }
}
