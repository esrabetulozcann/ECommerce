using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseModel>> GetAllAsync();
        Task<CategoryResponseModel> GetByIdAsync(int id);
        Task<CategoryResponseModel> GetByNameAsync(string name);
    }
}
