using ECommerce.Core.Models.Request.ProductImage;
using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IProductImageService
    {
        Task<ProductImagesResponseModel> GetImagesByProductIdAsync(int productId);
        Task<List<ProductImagesResponseModel>> GetAllImagesAsync();
        Task AddAsync(ProductImageRequestModel model);
        Task UpdateAsync(ProductImageRequestModel model);
        Task DeleteAsync(int id); // Ürünleri db den silme pasife al.
    }
}
