using ECommerce.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryTreeDTO>> GetAllCategoriesAsync();
        Task<CategoryTreeDTO?> GetCategoryTreeByNameAsync(string name);
        Task<List<CategoryTreeDTO>> SearchCategoryTreesAsync(string keyword);
        Task<List<CategoryTreeDTO>> SearchCategoryTreeWithAncestorsAsync(string keyword);
    }
}
