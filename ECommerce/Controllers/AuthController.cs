using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete.Managers;
using ECommerce.Core.Models.Request.User;
using ECommerce.Core.Models.Request.User_Login;
using ECommerce.Core.Models.Response.User_Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
        {
            var result = await _authService.LoginUserAsync(request);

            return result;
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterAsync([FromBody] UserAddRequestModel request)
        {
             await _authService.RegisterAsync(request);

            return Ok();
        }

    }
}
