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
    public class SizeTypeRepository : ISizeTypeRepository
    {
        private EcommerceContext _context;

        public SizeTypeRepository(EcommerceContext context)
        {
            _context = context;
        }

        

        public async Task<List<Size>> GetAllAsync()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return _context.Sizes.FirstOrDefault(s => s.Id == id);
        }

        public async Task<Size> GetByNameAsync(string name)
        {
            return _context.Sizes.FirstOrDefault(s => s.Name == name);
        }
        public async Task AddAsync(Size size)
        {
            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Size size)
        {
            _context.Sizes.Update(size);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var size = await _context.Sizes.FindAsync(id);
            if (size != null)
            {
                _context.Sizes.Remove(size);
                await _context.SaveChangesAsync();
            }
        }
       

        
    }
}
