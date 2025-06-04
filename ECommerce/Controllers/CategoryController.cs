using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryTreeDTO>>> GetAllCategoriesAsync()
        {
            return await _categoryService.GetAllCategoriesAsync();

        }


        [HttpGet("exact/{name}")]
        public async Task<IActionResult> GetByExactName(string name)
        {
            var result = await _categoryService.GetCategoryTreeByNameAsync(name);
            if (result == null)
                return NotFound("Kategori bulunamadı.");
            return Ok(result);
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string keyword)
        {
            var result = await _categoryService.SearchCategoryTreesAsync(keyword);
            return Ok(result);
        }


        [HttpGet("search-tree")]
        public async Task<IActionResult> SearchTreeWithAncestors([FromQuery] string keyword)
        {
            var result = await _categoryService.SearchCategoryTreeWithAncestorsAsync(keyword);
            return Ok(result);
        }

    }
}
