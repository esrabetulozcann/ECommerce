using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }


        [HttpGet("GetAllCartItem")]
        public async Task<ActionResult<List<CartItemRequestModel>>> GetAllAsync()
        {
            return await _cartItemService.GetAllAsync();
        }


        [HttpGet("{id}/GetByIdCartItem")]
        public async Task<ActionResult<CartItemRequestModel>> GetByIdAsync(int id)
        {
            return await _cartItemService.GetByIdAsync(id);
        }


        [HttpGet("{cartId}/GetByCartId")]
        public async Task<ActionResult<CartItemRequestModel>> GetByCartIdAsync(int cartId)
        {
            return await _cartItemService.GetByCartIdAsync(cartId);
        }
    }
}
