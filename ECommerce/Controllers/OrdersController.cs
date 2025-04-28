using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Order;
using ECommerce.Core.Models.Response.Orders;
using ECommerce.DataAccess.Models;
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


        [HttpGet("{id}/OrderById")]
        public async Task<ActionResult<OrdersResponseModel>> GetByIdAsync(int id)
        {
            return await _ordersService.GetOrderByIdAsync(id);
        }


        [HttpGet("{userId}/UserIdWithOrder")]
        public async Task<ActionResult<List<OrdersResponseModel>>> GetByUserIdWithOrder(int userId)
        {
            return await _ordersService.GetByUserIdAsync(userId);
        }



        /*[HttpPost] // Yeni order ekleme
        public async Task<ActionResult<OrderAddRequestModel>> AddAsync([FromBody] OrderAddRequestModel ordersResponseModel)
        {
            try
            {
                Order order = new Order
                {
                    UserId = ordersResponseModel.UserId,
                    OrderDate = DateTime.UtcNow,
                    AddressId = ordersResponseModel.AddressId,
                    Status = true,
                    
                };

                await _ordersService.AddAsync(order);
                return Ok("Sipariş başarıyla eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] OrderAddRequestModel orderAddRequestModel)
        {
            try
            {
                await _ordersService.AddAsync(orderAddRequestModel);
                return Ok("Sipariş başarıyla eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
