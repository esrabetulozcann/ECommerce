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
        Task<List<ProductImagesResponseModel>> GetImagesByProductIdAsync(int productId);
        Task<List<ProductImagesResponseModel>> GetAllImagesAsync();
    }
}
