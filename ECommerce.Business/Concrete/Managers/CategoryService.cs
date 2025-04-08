using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class CategoryService : ICategoryService
    {
        private CategoryRepository _categoryRepositor;
        public CategoryService(CategoryRepository categoryRepositor)
        {
            _categoryRepositor = categoryRepositor;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepositor.GetAllAsync();
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
