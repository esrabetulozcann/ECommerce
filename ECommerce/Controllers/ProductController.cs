using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Product;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<List<ProductResponseModel>>> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }
    }
}
