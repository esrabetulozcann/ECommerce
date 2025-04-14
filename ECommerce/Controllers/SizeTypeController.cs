using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Sizes;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SizeTypeController : ControllerBase
    {
        private readonly ISizeTypeService _sizeTypeService;
        public SizeTypeController(ISizeTypeService sizeTypeService)
        {
            _sizeTypeService = sizeTypeService;
        }

        [HttpGet("GetAllSizeType")]
        public async  Task<ActionResult<List<SizeTypeResponseModel>>> GetAllAsync()
        {
            return await _sizeTypeService.GetAllAsync();
        }


        [HttpGet("{id}/SizeType")]
        public async Task<ActionResult<SizeTypeResponseModel>> GetByIdAsynv(int id)
        {
            var sizeType = await _sizeTypeService.GetByIdAsync(id);
            return sizeType;
        }

        [HttpGet("SizeTypeName")]
        public async Task<ActionResult<SizeTypeResponseModel>> GetByName([FromQuery] string name)
        {
            var sizeType = await _sizeTypeService.GetByNameAsync(name);
            return sizeType;
        }
    }
}
