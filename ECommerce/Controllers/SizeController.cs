using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Sizes;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SizeController :ControllerBase
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        /// <summary>
        /// merhabaaaa
        /// </summary>
        /// <returns></returns>
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


        [HttpPost] // Yeni beden ekleme alanı
        public async Task<ActionResult<SizeResponseModel>> AddAsync([FromBody] Size size)
        {
            try
            {
                await _sizeService.AddAsync(size);
                return Ok("Beden başarıyla eklendi");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut] // Bedeni güncellemek için
        public async Task<ActionResult<SizeResponseModel>> UpdateAsync([FromBody] Size size)
        {
            try
            {
                await _sizeService.UpdateAsync(size);
                return Ok("Beden başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



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
