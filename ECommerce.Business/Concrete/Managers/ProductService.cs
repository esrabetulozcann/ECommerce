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
    public class ProductService : IProductService
    {
        private ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
             await _productRepository.AddAsync(product);
        }
        public async Task UpdateAsync(Product product)
        {
           await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<List<Product>> GetByCategoryIdAsync(int categoryId)
        {
            return await _productRepository.GetByCategoryIdAsync(categoryId);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _productRepository.GetByNameAsync(name);
        }

        public async Task<List<Product>> SearchAsync(string keyword)
        {
            return await _productRepository.SearchAsync(keyword);
        }

       
    }
}
