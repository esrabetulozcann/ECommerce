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

        Task AddAsync(ProductColour productColour);
        Task UpdateAsync(ProductColour productColour);
        Task DeleteAsync(int id);
        
    }
}
