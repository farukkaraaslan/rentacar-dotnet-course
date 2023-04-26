using Business.Absract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/Rental")]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService=rentalService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public void Add(Rental rental)
        { 
            _rentalService.Add(rental);

        }
    }
}
