using ECommerce.Core.Models.Request.Cart;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICartService
    {
        Task<List<CartRequestModel>> GetAllAsync();
        Task<List<CartRequestModel>> GetByUserId(int userId);
        Task<CartRequestModel> GetByIdAsync(int id);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(int id);

    }
}
