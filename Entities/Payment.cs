using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities
{
    public class Payment :IEntity
    {
        public int Id { get; set; }
        public string CardNumber{ get; set; }
        public string CardHolder { get; set; }
        public int CardExpirationYear { get; set; }
        public int CardExpirationMonth { get; set;}
        public string CardCvv { get; set; }
        public double Balance { get; set; }
    }
}
