using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Constants;
using Core.Helpers.FileHelper;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{

    public class CarImageManager :ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;

        public CarImageManager( ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal=carImageDal;
            _fileHelper=fileHelper;
        }
        public List<CarImage> GetAll()
        {
            return _carImageDal.GetAll();
        }

        public CarImage GetById(int id)
        {
          return  _carImageDal.Get(i => i.Id == id);
        }

        public void Add(CarImage carImage, IFormFile formFile)
        {
            carImage.Path = _fileHelper.AddFile(formFile, Paths.Car.Image);
            //carImage.CreatedAt = DateTime.Now;
            _carImageDal.Add(carImage); 
        }

        public void Update(CarImage carImage, IFormFile formFile)
        {
            carImage.Path = _fileHelper.UpdateFile(formFile, carImage.Path, Paths.Car.Image);
            carImage.CreatedAt = DateTime.Now;
            _carImageDal.Update(carImage);   
        }

        public void Delete(int id)
        {
            var image = GetById(id);
            _fileHelper.DeleteFile(Paths.Car.Image + image.Path);
            _carImageDal.Delete(id);
        }
    }
}
