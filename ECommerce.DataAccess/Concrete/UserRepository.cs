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
    public class UserRepository : IUserRepository
    {
        EcommerceContext _context;
        public UserRepository(EcommerceContext context)
        {
            _context = new();
        }

        
        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> FindByNameAsync(string name)
        {
            return await _context.Users.Where(u => u.FirstName == name).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDelete = true;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
                


        }

        public async Task<User> FindByEmailWithPasswordAsync(string email)
        {
            return await _context.Users
                .Where(u => u.Email == email && !u.IsDelete)
                .FirstOrDefaultAsync();
        }
    }
}
