using ECommerce.Core.Models.Response.Orders;
using ECommerce.Core.Models.Response.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IOrdersService
    {
        Task<List<OrdersResponseModel>> GetAllOrdersAsync();
        Task<OrdersResponseModel> GetOrderBeyIdAsync(int id);
        Task<UserResponseModel> GetByUserIdAsync(int id);
    }
}
