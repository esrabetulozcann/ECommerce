using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;
        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet("GetAllPaymentType")]
        public async Task<ActionResult<List<BaseDTO>>> GetAllAsync()
        {
            return await _paymentTypeService.GetAllAsync();
        }

        
        [HttpGet("{id}/GetById")]
        public async Task<ActionResult<BaseDTO>> GetByIdAsync(int id)
        {
            return await _paymentTypeService.GetByIdAsync(id);
        }


        [HttpGet("PaymentTypeGetByName")]
        public async Task<ActionResult<BaseDTO>> GetByName(string name)
        {
            return await _paymentTypeService.GetByNameAsync(name);
        }

    }
}
