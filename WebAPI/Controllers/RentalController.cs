﻿using Business.Absract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService=rentalService;
        }


        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll(); 
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            return Ok(result);
        }
        [HttpPost()]
        public void Add(Rental rental)
        {
            _rentalService.Add(rental);
        }

        [HttpPut()]
        public void Update(Rental rental)
        {
            _rentalService.Update(rental);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _rentalService.Delete(id);
        }
    }
}
