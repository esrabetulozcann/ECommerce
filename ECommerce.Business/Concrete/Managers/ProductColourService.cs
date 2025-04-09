using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Colours;
using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Abstract;
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
        private readonly IProductColourRepository _productColourRepository;

        public ProductColourService(IProductColourRepository productColourRepository)
        {
            _productColourRepository = productColourRepository;
        }

        public async Task<List<ProductColourResponseModel>> GetAllAsync()
        {
            var result = await _productColourRepository.GetAllAsync();
            List<ProductColourResponseModel> responseModels = new List<ProductColourResponseModel>();
            responseModels = result.Select(x => new ProductColourResponseModel
            {
                Id = x.Id,
                ColourId = x.ColourId,
                ProductId = x.ProductId,
                
            }).ToList();

            return responseModels;
        }


        public async Task<ProductColourResponseModel> GetByIdAsync(int id)
        {
            var result = await _productColourRepository.GetByIdAsync(id);
            if (result == null)
            {
                return new ProductColourResponseModel();
            }
            else
            {
                ProductColourResponseModel responseModel = new ProductColourResponseModel
                {
                    Id = result.Id,
                    ProductId = result.ProductId,
                    ColourId = result.ColourId,
                };
                return responseModel;
            }
        }
        public async Task<ColourResponseModel> GetByColourIdAsync(int id)
        {
            var result = await _productColourRepository.GetByColourIdAsync(id);
            if(result == null)
            {
                return new ColourResponseModel();
            }
            else
            {
                ColourResponseModel responseModel = new ColourResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    ProductColurId = result.ProductColours.First().Id,

                };
                return responseModel;
               
            }
        }

        

        public async Task<ProductResponseModel> GetByProductIdAsync(int id)
        {
            var result = await _productColourRepository.GetByProductIdAsync(id);
            if(result == null)
            {
                return new ProductResponseModel();
            }
            else
            {
                ProductResponseModel responseModel = new ProductResponseModel
                {
                    Id = result.Id,
                    Barcode = result.Barcode,
                    Brand = result.Brand,
                    CategoryId = result.CategoryId,
                    Name = result.Name,
                    Description = result.Description,
                    Quantity = result.Quantity,
                    Price = result.Price,

                };

                return responseModel;
            }
        }
    }
}
