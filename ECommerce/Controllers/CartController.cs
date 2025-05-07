using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Cart;
using ECommerce.Core.Models.Request.CartItem;
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

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CartAddRequestModel model)
        {
            try
            {
                await _cartService.AddAsync(model);
                return Ok("Sepete eklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{cartId}")]
        public async Task<ActionResult> UpdateAsync(int cartId, [FromBody] CartItemUpdateRequestModel model)
        {
            try
            {
                model.CartItemId = cartId;
                await _cartService.UpdateAsync(model);
                return Ok("Sepet güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
