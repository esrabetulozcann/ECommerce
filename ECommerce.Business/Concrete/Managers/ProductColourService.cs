using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class ProductColourService : IProductColourService
    {
        private ProductColourRepository _productColourRepository;

        public ProductColourService(ProductColourRepository productColourRepository)
        {
            _productColourRepository = productColourRepository;
        }

        public async Task<List<ProductColour>> GetAllAsync()
        {
            return await _productColourRepository.GetAllAsync();
        }

        public async Task<ProductColourResponseModel> GetByColourIdAsync(int id)
        {
            return await _productColourRepository.GetByColourIdAsync(id);
        }

        public async Task<ProductColourResponseModel> GetByIdAsync(int id)
        {
            return await _productColourRepository.GetByIdAsync(id);
        }

        public async Task<ProductColourResponseModel> GetByProductIdAsync(int id)
        {
            return await _productColourRepository.GetByProductIdAsync(id);
        }
    }
}
