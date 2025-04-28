using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICartItemRepository
    {
        Task<List<CartItem>> GetAllAsync();
        Task<CartItem> GetByIdAsync(int id);
        Task<CartItem> GetByCartIdAsync(int cartId);
        Task Add(CartItem cartItem);
    }
}
