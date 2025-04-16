using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Models;

namespace ECommerce.Business.Abstract
{
    public interface IParentCategoryService
    {
        Task<List<BaseDTO>> GetAllAsync();
        Task<List<ParentCategoryResponseModel>> GetByIdAsync(int id);
        Task<List<ParentCategoryResponseModel>> GetAllWithCategories();

    }
}
