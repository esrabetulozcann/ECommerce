using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IProductImagesRepository
    {
        Task<ProductImage> GetImagesByProductIdAsync(int productId);
        Task<List<ProductImage>> GetAllImagesAsync();

        Task AddAsync(ProductImage productImage);
        Task UpdateAsync(ProductImage productImage);
        Task DeleteAsync(int id);
    }
}
