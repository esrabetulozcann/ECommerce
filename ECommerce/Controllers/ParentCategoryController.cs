using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentCategoryController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public ParentCategoryController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpGet("with-categories")]
        public async Task<ActionResult<IEnumerable<ParentCategory>>> GetAllWithCategories()
        {
            return await _context.ParentCategories.ToListAsync();
        }


        [HttpGet]
        public async Task<ActionResult<ParentCategory>> GetAll()
        {
            var parentCategory =  await _context.ParentCategories.ToListAsync();
            return Ok(parentCategory);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ParentCategory>> GetById(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var category = await _context.ParentCategories.FindAsync(id);
            if (category == null)
                return NotFound();

            return category;
        }
    }
}
