using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymnetService;

        public PaymentController(IPaymentService paymnetService)
        {
                _paymnetService=paymnetService;
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _paymnetService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var resul = _paymnetService.GetById(id);
            return Ok(resul);
        }
        [HttpPost()]
        public void Add(Payment payment)
        {
            _paymnetService.Add(payment);
        }

        [HttpPut()]
        public void Update(Payment payment)
        {
            _paymnetService.Update(payment);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _paymnetService.Delete(id);
        }
    }
}
