using Azure.Core;
using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Token;
using ECommerce.Core.Models.Request.User;
using ECommerce.Core.Models.Request.User_Login;
using ECommerce.Core.Models.Response.User_Login;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            if (string.IsNullOrEmpty(userLoginRequest.Email) || string.IsNullOrEmpty(userLoginRequest.Password))
            {
                throw new ArgumentException(nameof(userLoginRequest));
            }

            string validatedEmail = (await _userService.FindByEmailAsync(userLoginRequest.Email)).Email;
            var password = (await _userService.FindByEmailWithPasswordAsync(userLoginRequest.Email)).Password;

            var isValid = VerifyPassword(userLoginRequest.Password, password);

            if (userLoginRequest.Email == validatedEmail && isValid)
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Email = userLoginRequest.Email });

                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
            }

            return response;
        }
        static bool VerifyPassword(string inputPassword, string storedBase64)
        {
            try
            {
                byte[] storedBytes = Convert.FromBase64String(storedBase64);

                int saltLength = 16; // or whatever length you used for salt generation
                byte[] salt = new byte[saltLength];
                byte[] storedHash = new byte[storedBytes.Length - saltLength];

                Buffer.BlockCopy(storedBytes, 0, salt, 0, saltLength);
                Buffer.BlockCopy(storedBytes, saltLength, storedHash, 0, storedHash.Length);

                using (var sha256 = new SHA256Managed())
                {
                    byte[] inputPasswordBytes = Encoding.UTF8.GetBytes(inputPassword);
                    byte[] saltedInput = new byte[inputPasswordBytes.Length + salt.Length];

                    Buffer.BlockCopy(inputPasswordBytes, 0, saltedInput, 0, inputPasswordBytes.Length);
                    Buffer.BlockCopy(salt, 0, saltedInput, inputPasswordBytes.Length, salt.Length);

                    byte[] inputHash = sha256.ComputeHash(saltedInput);

                    return inputHash.SequenceEqual(storedHash);
                }
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        public async Task RegisterAsync(UserAddRequestModel userAddRequestModel)
        {
            var existing = await _userService.FindByEmailAsync(userAddRequestModel.Email);
            if (existing != null)
                throw new Exception("Bu kullanıcı sistemde mevcut.");

            byte[] saltBytes = GenerateSalt();
            // Hash the password with the salt
            string hashedPassword = HashPassword(userAddRequestModel.Password, saltBytes);

            var newUser = new User
            {
                FirstName = userAddRequestModel.FirstName,
                LastName = userAddRequestModel.LastName,
                Password = hashedPassword,
                Email = userAddRequestModel.Email,
                Gender = userAddRequestModel.Gender,
                BirthDate = userAddRequestModel.BirthDate,
                PhoneNumber1 = userAddRequestModel.PhoneNumber1,
                PhoneNumber2 = userAddRequestModel.PhoneNumber2,
                CreatedDate = DateTime.UtcNow,
                IsDelete = false
            };
            await _userService.AddAsync(newUser);
        }

        static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16]; // Adjust the size based on your security requirements
                rng.GetBytes(salt);
                return salt;
            }
        }

        static string HashPassword(string password, byte[] salt)
        {
            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                // Concatenate password and salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                // Hash the concatenated password and salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Concatenate the salt and hashed password for storage
                byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }
    }
}
