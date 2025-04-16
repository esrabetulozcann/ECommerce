using ECommerce.Core.Models.Response.Product;
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
    }
}
