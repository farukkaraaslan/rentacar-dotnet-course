using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
      
        void Add(Invoice invoice);
        void Update(Invoice invoice);
        void Delete(int id);
        List<Invoice> GetAll();
        Invoice GetById(int id);
    }
}
