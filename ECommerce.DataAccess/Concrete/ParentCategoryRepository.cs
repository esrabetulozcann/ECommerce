using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Concrete
{
    public class ParentCategoryRepository : IParentCategoryRepository
    {
        EcommerceContext _context;
        public ParentCategoryRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<ParentCategory>> GetAllAsync()
        {
            return await _context.ParentCategories.Include(c => c.Categories).ToListAsync(); // Parent category lerin hepsini listeledim.
        }

        public async Task<List<ParentCategory>> GetByIdAsync(int id)
        {
            return await _context.ParentCategories.Include(pc => pc.Categories).Where(pc => pc.Id == id).ToListAsync();
        }

        public async Task<List<ParentCategory>> GetAllWithCategories()
        {
            var parentCategories = await _context.ParentCategories
                .Include(pc => pc.Categories)
                .ToListAsync();

            return parentCategories;
        }

        
    }
}
