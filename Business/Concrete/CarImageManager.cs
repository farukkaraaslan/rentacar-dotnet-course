using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Absract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
{

    public class CarImageManager :ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager( ICarImageDal carImageDal)
        {
            _carImageDal=carImageDal;
        }
        public List<CarImage> GetAll()
        {
            return _carImageDal.GetAll();
        }

        public CarImage GetById(int id)
        {
          return  _carImageDal.Get(i => i.CarId == id);
        }

        public void Add(CarImage carImage)
        {
           _carImageDal.Add(carImage);
        }

        public void Update(CarImage carImage)
        {
           _carImageDal.Update(carImage);   
        }

        public void Delete(int id)
        {
            _carImageDal.Delete(id);
        }
    }
}
