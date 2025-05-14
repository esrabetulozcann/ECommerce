using Azure.Core;
using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Token;
using ECommerce.Core.Models.Request.User_Login;
using ECommerce.Core.Models.Response.User_Login;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthService(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        
        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest userLoginRequest)
        {
            UserLoginResponse response = new();

            if(string.IsNullOrEmpty(userLoginRequest.Email) || string.IsNullOrEmpty(userLoginRequest.Password))
            {
                throw new ArgumentException(nameof(userLoginRequest));
            }

            string validatedEmail =(await _userService.FindByEmailAsync(userLoginRequest.Email)).Email;
            var validpassword = (await _userService.FindByEmailWithPasswordAsync(userLoginRequest.Email)).Password;

            if(userLoginRequest.Email == validatedEmail && userLoginRequest.Password == validpassword)
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Email = userLoginRequest.Email });

                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
            }

            return response;
        }
    }
}
