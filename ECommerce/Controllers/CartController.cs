using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService; 
        }



        [HttpGet("GetAllCart")]
        public async Task<ActionResult<List<CartRequestModel>>> GetAllAsync()
        {
            return await _cartService.GetAllAsync();
        }


        [HttpGet("{id}/GetById")]
        public async Task<ActionResult<CartRequestModel>> GetByIdAsync(int id)
        {
            return await _cartService.GetByIdAsync(id);
        }


        [HttpGet("{userId}/GetByUserId")]
        public async Task<ActionResult<List<CartRequestModel>>> GetByUserIdAsync(int userId)
        {
            return await _cartService.GetByUserId(userId);
        }



        [HttpDelete]
        public async Task<ActionResult<CartRequestModel>> DeleteAsync(int id)
        {
            try
            {
                await _cartService.DeleteAsync(id);
                return Ok("Sepet başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
