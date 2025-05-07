using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("GetAllInvoice")]
        public async Task<ActionResult<List<InvoiceResponseModel>>> GetAllAsync()
        {
            return await _invoiceService.GetAllAsync();
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<InvoiceResponseModel>> GetByIdAsync(int id)
        {
            return await _invoiceService.GetByIdAsync(id);
        }


        [HttpGet("GetByOrderID")]
        public async Task<ActionResult<InvoiceOrderDetailResponseModel>> GetByOrderIdAsync(int orderId)
        {
            return await _invoiceService.GetByOrderIdAsync(orderId);
        }
    }
}
