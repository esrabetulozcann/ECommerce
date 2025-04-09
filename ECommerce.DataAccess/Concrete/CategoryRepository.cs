using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        EcommerceContext _context;

        public CategoryRepository(EcommerceContext context)
        {
            _context = new();
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync(); // Tüm altkategorileri döndür dedim.

        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _context.Categories.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}
