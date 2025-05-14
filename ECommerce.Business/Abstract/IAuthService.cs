using ECommerce.Core.Models.Request.User_Login;
using ECommerce.Core.Models.Response.User_Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest userLoginRequest);
    }
}
