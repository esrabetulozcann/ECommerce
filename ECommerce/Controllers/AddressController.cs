using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Address;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AddressRequestModel>>> GetAllAsync()
        {
            return await _addressService.GetAllAsync();
        }


        [HttpGet("ActiveGetAll")]
        public async Task<ActionResult<List<AddressRequestModel>>> GetAllActiveAsync()
        {
            return await _addressService.GetAllActiveAsync();
        }


        [HttpGet("{id}/GetById")]
        public async Task<ActionResult<AddressRequestModel>> GetByIdAsync(int id)
        {
            return await _addressService.GetByIdAsync(id);
        }


        [HttpGet("{userId}/GetByUserId")]
        public async Task<ActionResult<List<AddressRequestModel>>> GetByUserIdAsync(int userId)
        {
            return await _addressService.GetByUserIdAsync(userId);
        }


        [HttpPost] //Yeni adress ekleme
        public async Task<ActionResult<AddressAddRequestModel>> AddAsync([FromBody] AddressAddRequestModel addressAddRequestModel)
        {
            try
            {
                await _addressService.AddAsync(addressAddRequestModel);
                return Ok("Yeni adres eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT: api/address/{addressId}/user/{userId}
        [HttpPut("{addressId}/user/{userId}")]
        public async Task<IActionResult> UpdateAsync(int addressId, int userId, AddressUpdateRequestModel model)
        {
            try
            {
                await _addressService.UpdateAsync(addressId, userId, model);
                return Ok("Adres başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _addressService.DeleteAsync(id);
                return Ok("Adres silindi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
