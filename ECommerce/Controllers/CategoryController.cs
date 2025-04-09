using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete.Managers;
using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<CategoryResponseModel>>> GetAll()
        {
            return await _categoryService.GetAllAsync();
        }


        // Belirli bir parent'ın alt kategorilerini çekmek için bu şekilde yazdım.
        [HttpGet("{id}/categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesByParent(int id)
        {
            //var categories = await _categoryService.GetByIdAsync(id);
            //return categories;
            return null;
        }
    }
}
