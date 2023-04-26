using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepostoryBase<Payment, RentACarDbContext>, IPaymentDal
    {
    }
}
