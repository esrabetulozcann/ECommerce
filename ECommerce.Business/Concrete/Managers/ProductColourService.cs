using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.Categories;
using ECommerce.Core.Models.Response.Colours;
using ECommerce.Core.Models.Response.Product;
using ECommerce.Core.Models.Response.Sizes;
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
        private IProductColourRepository _productColourRepository;

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
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                Colours = x.Colour.ProductColours.Select(c => new BaseDTO
                {
                    Id = c.Colour.Id,
                    Name = c.Colour.Name,
                }).ToList(),


            }).ToList();

            return responseModels;
        }




        public async Task<ProductColourResponseModel> GetByIdAsync(int id)
        {
            var result = await _productColourRepository.GetByIdAsync(id);

            var responseModel = new ProductColourResponseModel
            {
                ProductId = result.Product.Id,
                ProductName = result.Product.Name,
                Colours = result.Colour.ProductColours.Select(c => new BaseDTO
                {
                    Id = c.Colour.Id,
                    Name = c.Colour.Name,
                }).ToList()
            };

            return responseModel;
        }


    }
        

       
    
}
