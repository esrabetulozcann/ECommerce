using ECommerce.Core.Models.Response.Colours;
using ECommerce.Core.Models.Response.Orders;
using ECommerce.Core.Models.Response.Users;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderBeyIdAsync(int id);
        Task<User> GetByUserIdAsync(int id);
    }
}
