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
    public class SizeRepository : ISizeRepository
    {
         EcommerceContext _context;
        public SizeRepository(EcommerceContext context)
        {
            _context = new();
        }



        public async Task<List<Size>> GetAllAsync()
        {
            return await _context.Sizes.Include(st => st.SizeType).ToListAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return  _context.Sizes.Include(st => st.SizeType).FirstOrDefault(s => s.Id == id);
        }

        public async Task<Size> GetByNameAsync(string name)
        {
            return  _context.Sizes.Include(st => st.SizeType).FirstOrDefault(s => s.Name == name);
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
            if(size != null)
            {
                _context.Sizes.Remove(size);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<SizeType> GetBySizeTypeIdAsync(int id)
        {
            return await _context.SizeTypes.Where(st => st.Id == id).FirstOrDefaultAsync();
        }
    }
}
