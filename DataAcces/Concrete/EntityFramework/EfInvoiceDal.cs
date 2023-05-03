﻿using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfInvoiceDal : EfEntityRepostoryBase<Invoice, RentACarDbContext>, IInvoiceDal
    {
    }
}
