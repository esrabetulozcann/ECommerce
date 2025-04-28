using ECommerce.Core.Models.Request.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICartItemService
    {
        Task<List<CartItemRequestModel>> GetAllAsync();
        Task<CartItemRequestModel> GetByIdAsync(int id);
        Task<CartItemRequestModel> GetByCartIdAsync(int cartId);

    }
}
