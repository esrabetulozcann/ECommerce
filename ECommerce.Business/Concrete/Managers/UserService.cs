using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.User;
using ECommerce.Core.Models.Response.Users;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepositor)
        {
            _userRepository = userRepositor;
        }


        public async Task<UserResponseModel> FindByEmailAsync(string email)
        {
            var result = await _userRepository.FindByEmailAsync(email);
            if(result == null)
            {
                return new UserResponseModel();
            }
            else
            {
                UserResponseModel userResponseModel = new UserResponseModel
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Password = result.Password,
                    Email = result.Email,
                    Gender = result.Gender,
                    BirthDate = result.BirthDate,
                    CreatedDate = result.CreatedDate,
                    PhoneNumber1 = result.PhoneNumber1,
                    PhoneNumber2 = result.PhoneNumber2,
                    IsDelete = result.IsDelete,
                };
                return userResponseModel;
            }
        }

        public async Task<UserResponseModel> FindByIdAsync(int id)
        {
            var result = await _userRepository.FindByIdAsync(id);
            if(result == null)
            {
                return new UserResponseModel();
            }
            else
            {
                UserResponseModel userResponseModel = new UserResponseModel
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Password = result.Password,
                    Email = result.Email,
                    Gender = result.Gender,
                    BirthDate = result.BirthDate,
                    CreatedDate = result.CreatedDate,
                    PhoneNumber1 = result.PhoneNumber1,
                    PhoneNumber2 = result.PhoneNumber2,
                    IsDelete = result.IsDelete,
                };
                return userResponseModel;
            }
        }

        public async Task<UserResponseModel> FindByNameAsync(string name)
        {
            var result = await _userRepository.FindByNameAsync(name);
            if(result == null)
            {
                return new UserResponseModel();
            }
            else
            {
                UserResponseModel userResponseModel = new UserResponseModel
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Password = result.Password,
                    Email = result.Email,
                    Gender = result.Gender,
                    BirthDate = result.BirthDate,
                    CreatedDate = result.CreatedDate,
                    PhoneNumber1 = result.PhoneNumber1,
                    PhoneNumber2 = result.PhoneNumber2,
                    IsDelete = result.IsDelete,
                };
                return userResponseModel;
            }
        }

        public async Task<List<UserResponseModel>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();
            List<UserResponseModel> userResponseModels = new List<UserResponseModel>();
            userResponseModels = result.Select(u => new UserResponseModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Password = u.Password,
                Email = u.Email,
                Gender = u.Gender,
                BirthDate = u.BirthDate,
                CreatedDate = u.CreatedDate,
                PhoneNumber1 = u.PhoneNumber1,
                PhoneNumber2 = u.PhoneNumber2,
                IsDelete = u.IsDelete,
            }).ToList();

            return userResponseModels;
        }


        public async Task AddAsync(UserAddRequestModel userAddRequestModel)
        {
            var existing = await _userRepository.FindByEmailAsync(userAddRequestModel.Email);
            if (existing != null)
                throw new Exception("Bu kullanıcı sistemde mevcut.");


            var newUser = new User
            {
                FirstName = userAddRequestModel.FirstName,
                LastName = userAddRequestModel.LastName,
                Password = userAddRequestModel.Password,
                Email = userAddRequestModel.Email,
                Gender = userAddRequestModel.Gender,
                BirthDate = userAddRequestModel.BirthDate,
                PhoneNumber1 = userAddRequestModel.PhoneNumber1,
                PhoneNumber2 = userAddRequestModel.PhoneNumber2,
                CreatedDate = DateTime.UtcNow,
                IsDelete = false,
            };
            await _userRepository.AddAsync(newUser);
        }

       
        public async Task UpdateAsync(UserAddRequestModel model, int id)
        {
            var existing = await _userRepository.FindByIdAsync(id);
            if (existing == null)
                throw new Exception("Güncellenecek kullanıcı bulunamadı");

            existing.FirstName = model.FirstName;
            existing.LastName = model.LastName;
            existing.Password = model.Password;
            existing.Email = model.Email;
            existing.Gender = model.Gender;
            existing.BirthDate = model.BirthDate;

            await _userRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _userRepository.FindByIdAsync(id);
            if (existing == null)
                throw new Exception("Silinecek kullanıcı bulunamadı");

            await _userRepository.DeleteAsync(id);
        }
    }
}
