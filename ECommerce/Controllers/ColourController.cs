using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete.Managers;
using ECommerce.Core.Models.Response.Colours;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using ECommerce.DataAccess.Models;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColourController :ControllerBase
    {
        
        private readonly IColourService _colourService;

        public ColourController(IColourService colourService)
        {
            _colourService = colourService;
        }

        [HttpGet("GetAllColour")]
        public async Task<ActionResult<List<ColourResponseModel>>> GetAllAsync()
        {
            return await _colourService.GetAllAsync();
        }


        [HttpGet("{id}/colours")]
        public async Task<ActionResult<ColourResponseModel>> GetByIdAsync(int id)
        {
            var colours = await _colourService.GetByIdAsync(id);
            return colours;
        }

        [HttpGet("coloursByName")]
        public async Task<ActionResult<ColourResponseModel>> GetByNameAsync([FromQuery] string name)
        {
            var colours = await _colourService.GetByNameAsync(name);
            return colours;
        }


        [HttpPost] // Yeni renk ekleme
        public async Task<ActionResult<ColourResponseModel>> AddAsync([FromBody] Colour colour)
        {
            try
            {
                await _colourService.AddAsync(colour);
                return Ok("Beden başarıyla eklendi");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
