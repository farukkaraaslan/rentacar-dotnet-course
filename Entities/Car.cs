using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public double  DailyPrice { get; set; }
        public string Plate { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(CarState))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CarState State { get; set; }   

    }
}
