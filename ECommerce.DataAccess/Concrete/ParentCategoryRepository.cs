using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;

namespace ECommerce.DataAccess.Concrete
{
    public class ParentCategoryRepository : IParentCategoryRepository
    {
        private EcommerceContext _context;
        public ParentCategoryRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<List<ParentCategory>> GetAllAsync()
        {
            return _context.ParentCategories.ToList(); // Parent category lerin hepsini listeledim.
        }

        public async Task<ParentCategoryResponseModel> GetByIdAsync(int id)
        {
            var parentCategory = _context.ParentCategories
                 .Where(x => x.Id == id)
                 .Select(pc => new ParentCategoryResponseModel
                 {
                     Id = pc.Id,
                     Name = pc.Name,
                     Categories = pc.Categories.Select(c => new CategoryResponseModel
                     {
                         Id = c.Id,
                         Name = c.Name
                     }).ToList()
                 }).FirstOrDefault();

            return parentCategory;
        }
    }
}
