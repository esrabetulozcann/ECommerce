using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Invoice;
using ECommerce.Core.Models.Response.InvoiceDetail;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;
        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;   
        }

        [HttpGet("GetAllInvoiceDetail")]
        public async Task<ActionResult<List<InvoiceDetailResponseModel>>> GetAllAsync()
        {
            return await _invoiceDetailService.GetAllAsync();
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<InvoiceDetailResponseModel>> GetByIdAsync(int id)
        {
            return await _invoiceDetailService.GetByIdAsync(id);
        }


        [HttpGet("GetByInvoiceId")] 
        public async Task<ActionResult<List<InvoiceProductDetailResponseModel>>> GetProductDetailInvoiceAsync(int invoiceId)
        {
            return await _invoiceDetailService.GetProductDetailInvoiceAsync(invoiceId);
        }


    }
}
