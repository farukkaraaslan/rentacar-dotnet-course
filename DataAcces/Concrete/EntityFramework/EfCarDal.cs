using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarDal : EfEntityRepostoryBase<Car,RentACarDbContext> ,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using var context = new RentACarDbContext(); //transients

            var result = from car in context.Cars
                         join brand in context.Brands on car.BrandId equals brand.Id
                         join color in context.Colors on car.ColorId equals color.Id
                         select new CarDetailDto
                         {
                             Id = car.Id,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             DailyPrice = car.DailyPrice,
                             ModelYear = car.ModelYear,
                             Plate=car.Plate,
                         };
            return result.ToList();
        }
    }
}
