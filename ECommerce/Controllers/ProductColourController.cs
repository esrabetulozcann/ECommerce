using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.ProductColour;
using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Models;
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


        [HttpPost] // Yeni ürün rengi ekelenecek
        public async Task<ActionResult<ProductColourResponseModel>> AddAsync([FromBody] ProductColourRequestModel requestModel)
        {
            try
            { 
                
                await _productColourService.AddAsync(requestModel);
                return Ok("Ürün rengi başarıyla eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut] // Ürün rengi güncellenecek
        public async Task<ActionResult<ProductColourResponseModel>> UpdateAsync([FromBody] ProductColourRequestModel productColourRequestModel)
        {
            try
            {
                await _productColourService.UpdateAsync(productColourRequestModel);
                return Ok("Ürün rengi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")] // Ürünün rengini silme
        public async Task<ActionResult<ProductColourResponseModel>> DeleteAsync(int id)
        {
            try
            {
                await _productColourService.DeleteAsync(id);
                return Ok("Ürün rengi silindi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
