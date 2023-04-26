using Core.Utilities;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absract
{
    public interface ICarService
    {
        List<Car> GetAll(int? brandId=null, int? colorId=null);

        //List<Car> GetCarsByBrandId(int brandId);
        //List<Car> GetCarsByColorId(int colorId);
        List<CarDetailDto> GetCarDetails();
        Car GetById(int id);
        void Add(Car car);  
        void Update(Car car);
        void Delete(int id);

        void ChanceState(int carId, CarState carState);


    }
}
