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
    public class ProductColourRepository : IProductColourRepository
    {
         EcommerceContext _context;
        public ProductColourRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<ProductColour>> GetAllAsync()
        {
            return await _context.ProductColours
                .Include(pc => pc.Colour)
                .Include(pc => pc.Product).ThenInclude(p => p.Category)
                .Include(pc => pc.Product).ThenInclude(p => p.ProductColours).ThenInclude(pc => pc.Colour)
                .Include(pc => pc.Product).ThenInclude(p => p.ProductSizes).ThenInclude(ps => ps.Size)
                .ToListAsync();
        }

        public async Task<Colour> GetByColourIdAsync(int id)
        {
            return await _context.Colours.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductColour> GetByIdAsync(int id)
        {
            return await _context.ProductColours
                .Include(pc =>pc.Colour)
                .Include(pc=> pc.Product)
                .Where(pc => pc.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetByProductIdAsync(int id)
        {
            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
