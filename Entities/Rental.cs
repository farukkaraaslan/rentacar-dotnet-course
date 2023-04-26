using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities
{
    public class Rental :IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int RentedForDays{ get; set; }
        public double DailyPrice { get; set; }
        public double TotalPrice { get; set; } = 0;
        public DateTime RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }

    }
}
