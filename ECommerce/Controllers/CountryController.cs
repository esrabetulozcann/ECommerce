using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.Country;
using ECommerce.Core.Models.Response.Country;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("GetAllCountry")]
        public async Task<ActionResult<List<BaseDTO>>> GetAllCountryAsync()
        {
            return await _countryService.GetAllAsync();
        }


        [HttpGet("{id}/Country")]
        public async Task<ActionResult<BaseDTO>> GetByIdAsync(int id)
        {
            var country = await _countryService.GetByIdAsync(id);
            return country;
        }

        [HttpGet("CountryByName")]
        public async Task<ActionResult<BaseDTO>> GetByName([FromQuery] string name)
        {
            var country = await _countryService.GetByNameAsync(name);   
            return country;
        }


        [HttpGet("withCities")] // Ülkeleri şehirleriyle beraber getriyorum.
        public async Task<ActionResult<List<CountryResponseModel>>> GetAllWithCitiesAsync()
        {
            return await _countryService.GetAllWithCities();
        }


        [HttpPost] // Yeni ülke eklemek
        public async Task<ActionResult<CountryResponseModel>> AddAsync([FromBody] CountryAndColourRequestModel countryRequest)
        {
            try
            {
                Country country = new Country
                {
                    Name = countryRequest.Name,
                };
                await _countryService.AddAsync(country);
                return Ok("Yeni ülke başarıyla eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        
    }
}
