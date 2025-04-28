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
            return await _context.Orders.Include(o => o.User).ToListAsync();
        }

        public async Task<List<Order>> GetByUserIdAsync(int id)
        {
            return await _context.Orders
                        .Where(o => o.UserId == id)
                        .Include(o => o.User)
                        .ToListAsync();

            
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Where(o => o.Id == id)
                .Include(o => o.User)
                .FirstOrDefaultAsync();
        }

        public async Task<int> AddAsync(Order order)
        {
            await _context.Orders .AddAsync(order);
             await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task UpdateAsync(Order order)
        {
             _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
