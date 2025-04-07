using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CategoryController
    {
        private readonly EcommerceContext _context;
        public CategoryController(EcommerceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return await _context.Categories
                .Include(c => c.ParentCategory) // parentCategory ile ilişki var
                .ToListAsync();
        }


        // Belirli bir parent'ın alt kategorilerini çekmek için bu şekilde yazdım.
        [HttpGet("{id}/categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesByParent(int id)
        {
            var categories = await _context.Categories
                                           .Where(c => c.ParentCategoryId == id)
                                           .ToListAsync();
            /*if(categories == null)
            {
                return NotFound();
            }
            */
            return categories;
        }

       

    }
}
