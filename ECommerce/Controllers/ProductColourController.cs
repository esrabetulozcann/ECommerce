using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Colours;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductColourController :ControllerBase
    {
        private readonly IProductColourService _productColourService;

        public ProductColourController(IProductColourService productColourService)
        {
            _productColourService = productColourService;   
        }

        [HttpGet("GetAllProductColour")]
        public async Task<ActionResult<List<ProductColourResponseModel>>> GetAllAsync()
        {
            return await _productColourService.GetAllAsync();   
        }

        [HttpGet("{id}/ProductColour")]
        public async Task<ActionResult<ProductColourResponseModel>> GetByIdAsync(int id)
        {
            var productColours = await _productColourService.GetByIdAsync(id);
            return productColours;
        }
    }
}
