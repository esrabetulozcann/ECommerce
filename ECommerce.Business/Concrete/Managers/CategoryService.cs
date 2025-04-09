using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;

namespace ECommerce.Business.Concrete.Managers
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepositor;
        public CategoryService(ICategoryRepository categoryRepositor)
        {
            _categoryRepositor = categoryRepositor;
        }

        public async Task<List<CategoryResponseModel>> GetAllAsync()
        {
            var result =  await _categoryRepositor.GetAllAsync();

            List<CategoryResponseModel> responseModels = new List<CategoryResponseModel>();

            responseModels = result.Select(c => new CategoryResponseModel
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId
            }).ToList();

            return responseModels;
        }

        public async Task<CategoryResponseModel> GetByIdAsync(int id)
        {
            return await _categoryRepositor.GetByIdAsync(id);
        }

        public async Task<CategoryResponseModel> GetByNameAsync(string name)
        {
            return await _categoryRepositor.GetByNameAsync(name);
        }
    }
}
