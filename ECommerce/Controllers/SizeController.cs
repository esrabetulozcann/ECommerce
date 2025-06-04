using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Size;
using ECommerce.Core.Models.Response.Sizes;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class SizeController :ControllerBase
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }


        [HttpGet("GetAllSize")]
        public async Task<ActionResult<List<SizeResponseModel>>> GetAllAsync()
        {
            return await _sizeService.GetAllAsync();
        }


        [HttpGet("{id}/Sizes")]
        public async Task<ActionResult<SizeResponseModel>> GetByIdAsync(int id)
        {
            var sizes = await _sizeService.GetByIdAsync(id);
            return sizes;
        }


        [HttpGet("SizesByName")]
        public async Task<ActionResult<SizeResponseModel>> GetByNameAsync([FromQuery] string name)
        {
            var sizes = await _sizeService.GetByNameAsync(name);
            return sizes;
        }


        [HttpGet("by-sizetype/{sizeTypeId}")]
        public async Task<ActionResult<SizeTypeResponseModel>> GetBySizeTypeIdAsync(int id)
        {
            var result = await _sizeService.GetBySizeTypeIdAsync(id);
            return result;
        }


        [Authorize]
        [HttpPost] // Yeni beden ekleme alanı
        public async Task<ActionResult<SizeResponseModel>> AddAsync([FromBody] SizeRequestModel model)
        {
            try
            {
                await _sizeService.AddAsync(model);
                return Ok("Beden başarıyla eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpPut("{id} - update")] // Bedeni güncellemek için
        public async Task<ActionResult<SizeResponseModel>> UpdateAsync(int id, [FromBody] SizeRequestModel model)
        {
            try
            {
                // Size nesnesini kendimiz oluşturuyoruz:
                var updatedSize = new Size
                {
                    Id = id,
                    Name = model.Name,
                    SizeTypeId = model.SizeTypeId,
                    IsDelete = model.IsDelete,
                    ProductSizes = model.productSizes.Select(ps => new ProductSize
                    {
                        ProductId = ps.ProductId
                    }).ToList()
                };

                await _sizeService.UpdateAsync(updatedSize);
                return Ok("Beden başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SizeResponseModel>> DeleteAsync(int id)
        {
            try
            {
                await _sizeService.DeleteAsync(id);
                return Ok("Beden başarıyla silindi.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
