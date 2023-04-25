using Business.Absract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : Controller
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(int? brandId = null, int? colorId = null)
        {
            var result = _service.GetAll(brandId, colorId);
            return Ok(result);
        }

        [HttpGet("/details")]
        public IActionResult GetDetails()
        {
            var result = _service.GetCarDetails();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public void Add(Car car)
        {
            _service.Add(car);
        }

        [HttpPut]
        public void Update(Car car)
        {
            _service.Update(car);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

    }
}
