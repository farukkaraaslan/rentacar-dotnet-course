using Business.Absract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/cars/images")]
    public class CarImageController : Controller
    {
        private readonly ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService=carImageService;
        }
        [HttpPost]
        public void Add([FromForm] CarImage carImage, [FromForm(Name = "image")] IFormFile formFile)
        {
            _carImageService.Add(carImage, formFile);
        }

        [HttpPut]
        public void Update([FromForm] CarImage carImage, [FromForm(Name="image")] IFormFile formFile)
        {
            _carImageService.Update(carImage, formFile);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            return Ok(result);
        }
    }
}
