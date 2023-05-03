using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        List<CarImage> GetAll();
        CarImage GetById(int id);
        void Add(CarImage carImage,IFormFile formFile);
        void Update(CarImage carImage, IFormFile formFile);
        void Delete(int id);
    }
}
