using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("GetAllPayment")]
        public async Task<ActionResult<List<PaymentRequestModel>>> GetAllAsync()
        {
            return await _paymentService.GetAllAsync();
        }


        [HttpGet("{id}/GetById")]
        public async Task<ActionResult<PaymentRequestModel>> GetByIdAsync(int id)
        {
            return await _paymentService.GetById(id);
        }


        [HttpGet("IsOk")]
        public async Task<ActionResult<PaymentRequestModel>> IsOkAsync(bool isOk)
        {
            return await _paymentService.IsOkAsync(isOk);
        }
    }
}
