using Business.Abstract;
using Business.Rules;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;

namespace Business.Concrete
{
   
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly CarBusinessRules _rules;
       

        public CarManager(ICarDal carDal,CarBusinessRules rules)
        {
            _carDal = carDal;
            _rules = rules; 
        }

        public void Add(Car car)
        {
            _rules.ValidateCar(car);
            _rules.CheckIfCarExistByPlate(car.Plate);
            _rules.CheckIfPlateIsValid(car.Plate);
            car.State = CarState.Available;
           
            _carDal.Add(car);
        }

        public void Delete(int id)
        {
            _rules.CheckIfCarExist(id);
            _carDal.Delete(id);
        }

        public void ChanceState(int carId, CarState carState)
        {
             var car =GetById(carId);
             car.State = carState;
             _carDal.Update(car);
        }

        public void Update(Car car)
        {
            _rules.CheckIfCarExist(car.Id);
            _carDal.Update(car);
        }
        public List<Car> GetAll(int? brandId = null, int? colorId = null)
        {
            return GetCarsByBrandsAndColor(brandId, colorId);

        }
        public Car GetById(int id)
        {
            _rules.CheckIfCarExist(id);
           return _carDal.Get(c=> c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
        public CarDetailDto GetCarDetailById(int id)
        {
            return _carDal.GetCarDetailById(id);
        }

        //public List<Car> GetCarsByBrandId(int brandId)
        //{
        //   return _carDal.GetAll(c=> c.BrandId == brandId);
        //}

        //public List<Car> GetCarsByColorId(int colorId)
        //{
        //   return _carDal.GetAll(c=> c.ColorId == colorId); 
        //}

        private List<Car> GetCarsByBrandsAndColor(int? brandId, int? colorId)
        {
            var cars = _carDal.GetAll();

            if (brandId.HasValue)
            {
                cars = cars.Where(c=>c.BrandId == brandId.Value).ToList();  
            }

            if (colorId.HasValue)
            {
                cars = cars.Where(c => c.ColorId == colorId.Value ).ToList();
            }

            return cars;
        }

      
    }
}
