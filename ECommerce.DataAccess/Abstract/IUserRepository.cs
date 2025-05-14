using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> FindByIdAsync(int id);
        Task<User> FindByNameAsync(string name);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByEmailWithPasswordAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);

    }
}
