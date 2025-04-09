using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;

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
            return _context.Categories.ToList(); // Tüm altkategorileri döndür dedim.
            
        }

        public async Task<CategoryResponseModel> GetByIdAsync(int id)
        {
            //var category = await _context.Categories
            //    .Where(c => c.Id == id)
            //    .Select(c => new CategoryResponseModel
            //    {
            //        Id = c.Id,
            //        Name = c.Name,
            //        ParentCategoryId = c.ParentCategoryId,
            //        ParentCategoryName = c.ParentCategory.Name // Include gerekmez çünkü Select içinde
            //    })
            //    .FirstOrDefaultAsync();

            //return category;

            return null;
        }

        public async Task<CategoryResponseModel> GetByNameAsync(string name)
        {
            //var category = await _context.Categories
            //    .Where(c => c.Name == name)
            //    .Select(c => new CategoryResponseModel
            //    {
            //        Id = c.Id,
            //        Name = c.Name,
            //        ParentCategoryId = c.ParentCategoryId,
            //        ParentCategoryName = c.ParentCategory.Name
            //    })
            //    .FirstOrDefaultAsync();

            //return category;

            return null;
        }

    }
}
