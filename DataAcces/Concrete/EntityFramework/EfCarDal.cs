using Core.DataAccess.EntitiyFramework;
using Core.Utilities.Constants;
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
                         join image in context.CarImages on car.Id equals image.CarId into images
                         from image in images.DefaultIfEmpty()
                         select new CarDetailDto
                         {
                             Id = car.Id,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             DailyPrice = car.DailyPrice,
                             ModelYear = car.ModelYear,
                             Plate=car.Plate,
                             Image = image.Path != null ? image.Path : "default-image.jpg"
                         };

            return result.ToList();
        }

        public CarDetailDto GetCarDetailById(int id)
        {
            using var context = new RentACarDbContext(); //transients

            var result = from car in context.Cars
                         join brand in context.Brands on car.BrandId equals brand.Id
                         join color in context.Colors on car.ColorId equals color.Id
                         join image in context.CarImages on car.Id equals image.CarId into images
                         from image in images.DefaultIfEmpty()
                         where car.Id == id
                         select new CarDetailDto
                         {
                             Id = car.Id,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             DailyPrice = car.DailyPrice,
                             ModelYear = car.ModelYear,
                             Plate = car.Plate,
                             Image= image.Path!= null ? image.Path: Paths.Car.DefaultImagePath   
                         };
            return result.FirstOrDefault();
        }
    }

}
