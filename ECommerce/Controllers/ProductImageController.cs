using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.ProductImage;
using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Models;
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
        public async Task<ActionResult<ProductImagesResponseModel>> GetByIdAsync(int id)
        {
            return await _productImageService.GetImagesByProductIdAsync(id);
        }



        [HttpPost] // Yeni ürün görseli eklendi.
        public async Task<ActionResult<ProductImagesResponseModel>> AddAsync([FromBody] ProductImageRequestModel requestModel)
        {
            try
            {
                await _productImageService.AddAsync(requestModel);
                return Ok("Ürün görseli başarıyla eklendi.");

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut] // Ürün gösrelinin güncellenmesi
        public async Task<ActionResult<ProductImagesResponseModel>> UpdateAsync([FromBody] ProductImageRequestModel productImageRequest)
        {
            try
            {
                await _productImageService.UpdateAsync(productImageRequest);
                return Ok("Ürün görseli başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")] // Ürün görselini silme
        public async Task<ActionResult<ProductImagesResponseModel>> DeleteAsync(int id)
        {
            try
            {
                await _productImageService.DeleteAsync(id);
                return Ok("Ürün görseli silindi");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
