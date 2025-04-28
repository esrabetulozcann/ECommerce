using ECommerce.Core.Models.Request.ProductColour;
using ECommerce.Core.Models.Response.Colours;
using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IProductColourService
    {
        Task<List<ProductColourResponseModel>> GetAllAsync();
        Task<ProductColourResponseModel> GetByIdAsync(int id);
        Task AddAsync(ProductColourRequestModel model);
        Task UpdateAsync(ProductColourRequestModel model);
        Task DeleteAsync(int id);
        
    }
}
