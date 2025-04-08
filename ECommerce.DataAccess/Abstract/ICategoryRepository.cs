using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<CategoryResponseModel> GetByIdAsync(int id);
        Task<CategoryResponseModel> GetByNameAsync(String name);
    }
}
