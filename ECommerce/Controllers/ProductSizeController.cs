using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.ProductSize;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeService _productSizeService;
        public ProductSizeController(IProductSizeService productSizeService)
        {
            _productSizeService = productSizeService;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddProductSize([FromBody] ProductSizeAddRequestModel sizeAddRequestModel)
        {
            if (sizeAddRequestModel.ProductId <= 0 || sizeAddRequestModel.SizeId <= 0)
            {
                return BadRequest("Geçersiz ProductId veya SizeId");
            }

            await _productSizeService.AddAsync(sizeAddRequestModel.ProductId, sizeAddRequestModel.SizeId);
            return Ok("ProductSize başarıyla eklendi.");
        }

        [HttpGet("exists")]
        public async Task<IActionResult> CheckIfExists([FromQuery] int productId, [FromQuery] int sizeId)
        {
            var exists = await _productSizeService.ExistsAsync(productId, sizeId);
            return Ok(exists);
        }

        [HttpGet("product/{productId}/sizes")]
        public async Task<IActionResult> GetSizesByProductId(int productId)
        {
            var sizes = await _productSizeService.GetSizesByProductIdAsync(productId);
            return Ok(sizes);
        }

        [HttpGet("size/{sizeId}/products")]
        public async Task<IActionResult> GetProductsBySizeId(int sizeId)
        {
            var products = await _productSizeService.GetProductsBySizeIdAsync(sizeId);
            return Ok(products);
        }


    }
}
