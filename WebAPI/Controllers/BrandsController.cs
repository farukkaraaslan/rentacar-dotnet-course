
using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : Controller
    {
        private readonly IBrandService _service;
        public BrandsController (IBrandService service)
        {
            _service = service;
        }
        
        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpGet("brand")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var result = _service.GetByName(name);
            return Ok(result);
        }

        [HttpPost()]
        public void Add(Brand brand)
        {
            _service.Add(brand);
        }

        [HttpPut()]
        public void Update(Brand brand)
        {
            _service.Update(brand);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
       
    }
}
