using ECommerce.Core.Models.Response.Colours;
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
    public class ColourRepository : IColourRepository
    {
         EcommerceContext _context;
        public ColourRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task AddAsync(Colour colour)
        {
            await _context.Colours.AddAsync(colour);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Colour>> GetAllAsync()
        {
            return await _context.Colours.Include(c => c.ProductColours).ToListAsync();
        }

        public async Task<Colour> GetByIdAsync(int id)
        {
            return  await _context.Colours.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Colour> GetByNameAsync(string name)
        {
            return await _context.Colours.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}
