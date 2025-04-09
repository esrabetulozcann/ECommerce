using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IProductColourRepository
    {
        Task<List<ProductColour>> GetAllAsync();
        Task<ProductColour> GetByIdAsync(int id);

        Task<Colour> GetByColourIdAsync(int id);
        Task<Product> GetByProductIdAsync(int id);
    }
}
