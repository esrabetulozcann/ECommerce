using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Models;

namespace ECommerce.DataAccess.Abstract
{
    public interface IParentCategoryRepository
    {
        //Generic Repository Uygulanacak - Faz 2
        Task<List<ParentCategory>> GetAllAsync();
        Task<List<ParentCategory>> GetByIdAsync(int id);
        Task<List<ParentCategory>> GetAllWithCategories();


    }
}
