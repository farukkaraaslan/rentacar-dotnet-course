﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class PaymentDto
    {
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public int CardExpirationYear { get; set; }
        public int CardExpirationMonth { get; set; }
        public string CardCvv { get; set; }

        [JsonIgnore]
        public double Price { get; set; }
    }
}
