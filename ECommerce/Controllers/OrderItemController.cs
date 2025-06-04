using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.OrderItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }


        [HttpGet("GetAllOrderItem")]
        public async Task<ActionResult<List<AllOrderItemRequestModel>>> GetAllAsync()
        {
            return await _orderItemService.GetAllAsync();
        }


        [HttpGet("{id}/orderItemId")]
        public async Task<ActionResult<AllOrderItemRequestModel>> GetByIdAsync(int id)
        {
            return await _orderItemService.GetByIdAsync(id);
        }


        [HttpGet("{orderId}/orderItemByOrderId")]
        public async Task<ActionResult<List<OrderItemRequestModel>>> GetByOrderIdAsync(int orderId)
        {
            return await _orderItemService.GetByOrderIdAsync(orderId);
        }
    }
}
