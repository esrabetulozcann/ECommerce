using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.Town;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TownController : ControllerBase
    {

        private readonly ITownService _townService;

        public TownController(ITownService townService)
        {
            _townService = townService;
        }


        [HttpGet("GetAllTown")]
        public async Task<ActionResult<List<BaseDTO>>> GetAllAsync()
        {
            return await _townService.GetAllAsync();
        }


        [HttpGet("{id}/GetByIdTown")]
        public async Task<ActionResult<BaseDTO>> GetByIdAsync(int id)
        {
            return await _townService.GetByIdAsync(id);
        }


        [HttpGet("GetByNameTown")]
        public async Task<ActionResult<BaseDTO>> GetByNameAsync(string name)
        {
            return await _townService.GetByNameAsync(name);
        }


        [HttpGet("WithDistrict")]
        public async Task<ActionResult<List<TownWithDistrictRequestModel>>> GetAllWithDistrictAsync()
        {
            return await _townService.GetAllWithDistrict();
        }



        [HttpPost] // Yeni ilçe eklemek
        public async Task<ActionResult<BaseDTO>> AddAsync([FromBody] TownAddRequestModel addRequestModel)
        {
            try
            {
                Town town = new Town
                {
                    Name = addRequestModel.Name,
                    CityId = addRequestModel.CityId,
                };

                await _townService.AddAsync(town);
                return Ok("Yeni ilçe başarıyla eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
