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


        public async Task<ProductColour> GetByIdAsync(int id)
        {
            return await _context.ProductColours
                .Include(pc =>pc.Colour)
                .Include(pc=> pc.Product)
                .Where(pc => pc.Id == id).FirstOrDefaultAsync();
        }


        public async Task AddAsync(ProductColour productColour)
        {
            await _context.ProductColours.AddAsync(productColour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductColour productColour)
        {
             _context.ProductColours.Update(productColour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productColour = await _context.ProductColours.FindAsync(id);
            if(productColour != null)
            {
                productColour.IsDelete = true;
                _context.ProductColours.Update(productColour);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
