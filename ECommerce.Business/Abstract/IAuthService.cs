using ECommerce.Core.Models.Request.User;
using ECommerce.Core.Models.Request.User_Login;
using ECommerce.Core.Models.Response.User_Login;

namespace ECommerce.Business.Abstract
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest userLoginRequest);
      public  Task RegisterAsync(UserAddRequestModel userAddRequestModel);
    }
}
