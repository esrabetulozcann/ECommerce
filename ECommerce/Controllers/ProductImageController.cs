using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Product;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("GetAllProductImage")]
        public async Task<ActionResult<List<ProductImagesResponseModel>>> GetAllImageAsync()
        {
            return await _productImageService.GetAllImagesAsync();
        }

        [HttpGet("{id}/productImageId")]
        public async Task<ActionResult<List<ProductImagesResponseModel>>> GetByIdAsync(int id)
        {
            return await _productImageService.GetImagesByProductIdAsync(id);
        }
    }
}
