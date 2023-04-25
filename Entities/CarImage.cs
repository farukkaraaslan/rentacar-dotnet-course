using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities
{
    public class CarImage :IEntity
    {
        [Key]
        public int Id { get; set; }

        public int  CarId { get; set; }
        public string Path { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
