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
    public class CategoryRepository : ICategoryRepository
    {
        EcommerceContext _context;
        public CategoryRepository(EcommerceContext context)
        {
            _context = new();
        }

        

        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.IsActive == true)
                .ToListAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.IsActive == true)
                .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesByListNameAsync(string keyword)
        {
            return await _context.Categories
                .Where(c => c.Name.ToLower().Contains(keyword.ToLower()) && c.IsActive == true)
                .ToListAsync();
        }


        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower() && c.IsActive == true);
        }
    }
}
