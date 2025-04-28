using ECommerce.Core.Models.Request.Order;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllAsync();
        Task<OrderItem> GetByIdAsync(int id);
        Task<OrderItem> GetByOrderIdAsync(int id);
        Task AddAsync(OrderItem orderItem);

    }
}
