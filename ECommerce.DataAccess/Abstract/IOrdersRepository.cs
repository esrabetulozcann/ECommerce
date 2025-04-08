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
        Task<List<OrdersResponseModel>> GetAllOrdersAsync();
        Task<OrdersResponseModel> GetOrderBeyIdAsync(int id);
        Task<UserResponseModel> GetByUserIdAsync(int id);
    }
}
