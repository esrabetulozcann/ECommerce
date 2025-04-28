using ECommerce.Core.Models.Request.Order;
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
    public class OrderItemRepository :IOrderItemRepository
    {
        EcommerceContext _context;
        public OrderItemRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await _context.OrderItems.Where(oi => oi.Id == id).FirstOrDefaultAsync();
        }

        public async Task<OrderItem> GetByOrderIdAsync(int id)
        {
            return await _context.OrderItems.Where(oi => oi.OrderId == id).FirstOrDefaultAsync();
        }
    }
}
