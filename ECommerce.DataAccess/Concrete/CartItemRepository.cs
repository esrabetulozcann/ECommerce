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
    public class CartItemRepository : ICartItemRepository
    {
        EcommerceContext _context;
        public CartItemRepository(EcommerceContext context)
        {
            _context = new();
        }

        

        public async Task<List<CartItem>> GetAllAsync()
        {
            return await _context.CartItems.ToListAsync();
        }

        public async Task<CartItem> GetByCartIdAsync(int cartId)
        {
            return await _context.CartItems.Where(ci => ci.CartId == cartId).FirstOrDefaultAsync();
        }

        public async Task<CartItem> GetByIdAsync(int id)
        {
            return await _context.CartItems.Where(ci => ci.Id == id).FirstOrDefaultAsync();
        }


        public async Task Add(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
