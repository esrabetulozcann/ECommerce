using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.User;
using ECommerce.Core.Models.Response.Users;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseModel>>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }


        [HttpGet("FindByEmail")]
        public async Task<ActionResult<UserResponseModel>> FindByEmailAsync([FromQuery] string email)
        {
            return await _userService.FindByEmailAsync(email);
        }


        [HttpGet("{id}/FindById")]
        public async Task<ActionResult<UserResponseModel>> FindByIdAsync(int id)
        {
            return await _userService.FindByIdAsync(id);
        }



        [HttpGet("FindByName")]
        public async Task<ActionResult<UserResponseModel>> FindByNameAsync([FromQuery] string name)
        {
            return await _userService.FindByNameAsync(name);
        }


        [HttpPost] // Yeni kullanıcı ekleme
        public async Task<ActionResult<UserAddRequestModel>> AddAsync([FromBody]  UserAddRequestModel model)
        {
            try
            {
                await _userService.AddAsync(model);
                return Ok("Üye olundu.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPut("{id}")] // Kullanıcı bilgilerini güncelleme
        public async Task<ActionResult<UserAddRequestModel>> UpdateAsync(int id, [FromBody] UserAddRequestModel model)
        {
            try
            {
                await _userService.UpdateAsync(model, id);
                return Ok("Bilgiler güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")] // kullanıcı silme
        public async Task<ActionResult<UserAddRequestModel>> DeleteAsync(int id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok("Kullanıcı silindi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
