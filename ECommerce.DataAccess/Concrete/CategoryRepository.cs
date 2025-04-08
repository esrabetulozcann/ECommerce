using ECommerce.Core.Models.Response.Categories;
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
        private EcommerceContext _context;
        public CategoryRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return _context.Categories.ToList(); // Tüm altkategorileri döndür dedim.
        }

        public async Task<CategoryResponseModel> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentCategoryId = c.ParentCategoryId,
                    ParentCategoryName = c.ParentCategory.Name // Include gerekmez çünkü Select içinde
                })
                .FirstOrDefaultAsync();

            return category;
        }

        public async Task<CategoryResponseModel> GetByNameAsync(string name)
        {
            var category = await _context.Categories
                .Where(c => c.Name == name)
                .Select(c => new CategoryResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentCategoryId = c.ParentCategoryId,
                    ParentCategoryName = c.ParentCategory.Name
                })
                .FirstOrDefaultAsync();

            return category;
        }

    }
}
