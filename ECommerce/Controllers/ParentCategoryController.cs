using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Categories;
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
        private readonly IParentCategoryService _parentCategoryService;

        public ParentCategoryController(IParentCategoryService parentCategoryService)
        {
            _parentCategoryService = parentCategoryService;
        }


        [HttpGet("getAll")]
        public async Task<ActionResult<List<ParentCategoryResponseModel>>> GetAll()
        {
            return await _parentCategoryService.GetAllAsync();

        }



        [HttpGet("{id}/ParentCategory")]
        public async Task<ActionResult<ParentCategoryResponseModel>> GetById(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var parentCategory = await _parentCategoryService.GetByIdAsync(id);
                return parentCategory;
            }
        }

        [HttpGet("with-categories")]
        public async Task<ActionResult<List<ParentCategoryResponseModel>>> GetAllWithCategories()
        {
            return await _parentCategoryService.GetAllWithCategories();
        }





    }
}
