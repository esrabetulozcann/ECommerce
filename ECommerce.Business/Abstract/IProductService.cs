using ECommerce.Core.Models.Request.Product;
using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IProductService
    {
        Task<List<ProductResponseModel>> GetAllAsync();
        Task<ProductResponseModel> GetByIdAsync(int id);
        Task<ProductResponseModel> GetByNameAsync(string name);
        Task AddAsync(ProductRequestModel model);
        Task UpdateAsync(ProductRequestModel model, int id);
        Task DeleteAsync(int id); // Ürünleri db den silme pasife al.

        Task<List<ProductResponseModel>> GetByCategoryIdAsync(int categoryId);
        Task<List<ProductResponseModel>> SearchAsync(string keyword);
    }
}
