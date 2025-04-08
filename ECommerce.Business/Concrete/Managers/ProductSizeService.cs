using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public  class ProductSizeService : IProductSizeService
    {
        private ProductSizeRepository _productSizeRepository;
        public ProductSizeService(ProductSizeRepository productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }

        public async Task AddAsync(ProductSize productSize)
        {
            await _productSizeRepository.AddAsync(productSize);
        }

        public async Task<bool> ExistsAsync(int productId, int sizeId)
        {
            return await _productSizeRepository.ExistsAsync(productId, sizeId);
        }

        public async Task<List<Product>> GetProductsBySizeIdAsync(int sizeId)
        {
            return await _productSizeRepository.GetProductsBySizeIdAsync(sizeId);
        }

        public async Task<List<Size>> GetSizesByProductIdAsync(int productId)
        {
            return await _productSizeRepository.GetSizesByProductIdAsync(productId);
        }

        public async Task RemoveAsync(ProductSize productSize)
        {
            await _productSizeRepository.RemoveAsync(productSize);
        }
    }
}
