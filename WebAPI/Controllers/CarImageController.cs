using Business.Absract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/carimages")]
    public class CarImageController : Controller
    {
        private readonly ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService=carImageService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            return Ok(result);
        }
    }
}
