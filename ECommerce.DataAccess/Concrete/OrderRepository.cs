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
        EcommerceContext _context;
        public OrderRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<User> GetByUserIdAsync(int id)
        {
            return await _context.Orders
                        .Where(o => o.UserId == id)
                        .Select(o => o.User)
                        .FirstOrDefaultAsync();
        }

        public async Task<Order> GetOrderBeyIdAsync(int id)
        {
            return await _context.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
        }
    }
}
