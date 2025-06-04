using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.District;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }


        [HttpGet("GetAllDistrict")]
        public async Task<ActionResult<List<BaseDTO>>> GetAllAsync()
        {
            return await _districtService.GetAllAsync();
        }


        [HttpGet("{id}/GetByIdDistrict")]
        public async Task<ActionResult<BaseDTO>> GetByIdDistrict(int id)
        {
            return await _districtService.GetByIdAsync(id);
        }


        [HttpGet("GetByNameDistrict")]
        public async Task<ActionResult<BaseDTO>> GetByNameAsync(string name)
        {
            return await _districtService.GetByNameAsync(name);
        }

        [Authorize]// Yetkili kullanıcı için
        [HttpPost] // Yeni mahalle ekleniyor
        public async Task<ActionResult<DistrictResponseModel>> AddAsync([FromBody] DistrictResponseModel districtResponseModel)
        {
            try
            {
                District district = new District
                {
                    Name = districtResponseModel.Name,
                    TownId = districtResponseModel.TownId,
                };

                await _districtService.AddAsync(district);
                return Ok("Mahalle başarıyla eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
