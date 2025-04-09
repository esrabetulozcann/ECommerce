using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class ProductImageService : IProductImageService
    {
        private IProductImagesRepository _productImagesRepository;

        public ProductImageService(IProductImagesRepository productImagesRepository)
        {
            _productImagesRepository = productImagesRepository;
        }

        public async Task<List<ProductImagesResponseModel>> GetAllImagesAsync()
        {
            return await _productImagesRepository.GetAllImagesAsync();
        }

        public async Task<List<ProductImagesResponseModel>> GetImagesByProductIdAsync(int productId)
        {
            return await _productImagesRepository.GetImagesByProductIdAsync(productId);
        }
    }
}
