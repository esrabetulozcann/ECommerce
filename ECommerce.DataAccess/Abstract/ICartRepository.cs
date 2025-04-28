using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllAsync();
        Task<List<Cart>> GetByUserIdAsync(int userId);
        Task<Cart> GetByIdAsync(int id);

        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(int id);

    }
}
