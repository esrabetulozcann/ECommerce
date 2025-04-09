using ECommerce.Core.Models.Response.Orders;
using ECommerce.Core.Models.Response.Users;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class OrderRepository : IOrdersRepository
    {
        private EcommerceContext _context;
        public OrderRepository(EcommerceContext context)
        {
            _context = context;
        }

        public Task<List<OrdersResponseModel>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseModel> GetByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersResponseModel> GetOrderBeyIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
