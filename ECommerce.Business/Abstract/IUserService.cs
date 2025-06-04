using ECommerce.Core.Models.Request.User;
using ECommerce.Core.Models.Response.Users;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IUserService
    {
        Task<List<UserResponseModel>> GetAllAsync();
        Task<UserResponseModel> FindByIdAsync(int id);
        Task<UserResponseModel> FindByNameAsync(string name);
        Task<UserResponseModel> FindByEmailAsync(string email);
        Task<User> FindByEmailWithPasswordAsync(string email);
        Task AddAsync(User userAddRequestModel);
        Task UpdateAsync(UserAddRequestModel model, int id);
        Task DeleteAsync(int id);
    }
}
