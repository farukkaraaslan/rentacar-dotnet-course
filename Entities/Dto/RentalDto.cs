using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class RentalDto
    {
        public int CarId { get; set; }
        public int RentedForDays { get; set; }
        public double DailyPrice { get; set; }
        public PaymentDto Payment  { get; set; }
    }
}
