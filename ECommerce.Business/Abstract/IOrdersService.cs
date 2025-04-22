using ECommerce.Core.Models.Response.Orders;
using ECommerce.Core.Models.Response.Users;
using ECommerce.DataAccess.Models;
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
        Task<OrdersResponseModel> GetOrderByIdAsync(int id);
        Task<List<OrdersResponseModel>> GetByUserIdAsync(int id);

        Task AddAsync(Order order);
    }
}
