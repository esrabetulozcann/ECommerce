using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Orders;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }


        [HttpGet("GetAllOrder")]
        public async Task<ActionResult<List<OrdersResponseModel>>> GetAllOrdersAsync()
        {
            return await _ordersService.GetAllOrdersAsync();
        }

    }
}
