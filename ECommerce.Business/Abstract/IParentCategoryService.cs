using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Models;

namespace ECommerce.Business.Abstract
{
    public interface IParentCategoryService
    {
        Task<List<ParentCategoryResponseModel>> GetAllAsync();
        Task<ParentCategoryResponseModel> GetByIdAsync(int id);
        Task<List<ParentCategoryResponseModel>> GetAllWithCategories();

    }
}
