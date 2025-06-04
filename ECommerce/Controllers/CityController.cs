using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.City;
using ECommerce.Core.Models.Response.City;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("GetAllCities")]
        public async Task<ActionResult<List<CityResponseModel>>> GetAllCities()
        {
            return await _cityService.GetAllAsync();
        }


        [HttpGet("{id}/Cities")]
        public async Task<ActionResult<CityResponseModel>> GetById(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            return city;
        }


        [HttpGet("GetByNameCity")]
        public async Task<ActionResult<CityResponseModel>> GetByName([FromQuery] string name)
        {
            var city = await _cityService.GetByNameAsync(name);
            return city;
        }

        [HttpGet("WithTown")]
        public async Task<ActionResult<List<CityWithTownRequestModel>>> GetAllWithTown()
        {
            return await _cityService.GetAllWithTown();
        }


        [HttpPost] // Yeni şehir ekleme
        public async Task<ActionResult<CityResponseModel>> AddAsync([FromBody] CityAddRequestModel cityAddRequestModel) 
        {
            try
            {
                City city = new City
                {
                    Name = cityAddRequestModel.Name,
                    CountryId = cityAddRequestModel.CountryId,
                };

                await _cityService.AddAsync(city);
                return Ok("Şehir başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
