using Business.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _invoiceService.GetAll();
            return Ok(result);
        }
    }
}
