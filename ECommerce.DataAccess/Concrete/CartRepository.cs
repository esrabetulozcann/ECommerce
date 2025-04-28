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
    public class CartRepository : ICartRepository
    {
        EcommerceContext _context;
        public CartRepository(EcommerceContext context)
        {
            _context = new();
        }

       

        public async Task<List<Cart>> GetAllAsync()
        {
            return await _context.Carts.Include(c => c.User).ToListAsync();
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _context.Carts.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Cart>> GetByUserIdAsync(int userId)
        {
            return await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
        }


        public async Task AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

      
        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if(cart != null)
            {
                cart.IsDelete = true;
                _context.Carts.Update(cart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
