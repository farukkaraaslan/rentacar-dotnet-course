using Business.Absract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/colors")]
    public class ColorController : Controller
    {
       private readonly IColorService _service;

        public ColorController( IColorService service)
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
            var resul = _service.GetById(id);
            return Ok(resul);
        }
        [HttpPost()]
        public void Add(Color color)
        {
            _service.Add(color);
        }

        [HttpPut()]
        public void Update(Color color)
        {
            _service.Update(color);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        [HttpGet("barand")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var result = _service.GetByName(name);
            return Ok(result);
        }
    }
}
