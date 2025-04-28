using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.ProductColour;
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
        private IProductRepository _productRepository;
        private IColourRepository _colourRepository;

        public ProductColourService(
            IProductColourRepository productColourRepository,
            IProductRepository productRepository,
            IColourRepository colourRepository)
        {
            _productColourRepository = productColourRepository;
            _productRepository = productRepository;
            _colourRepository = colourRepository;
        }

        
        public async Task<List<ProductColourResponseModel>> GetAllAsync()
        {
            var result = await _productColourRepository.GetAllAsync();
            List<ProductColourResponseModel> responseModels = new List<ProductColourResponseModel>();

            responseModels = result.Select(x => new ProductColourResponseModel
            {
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                IsDelete = x.IsDelete,
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
                IsDelete= result.IsDelete,
                Colours = result.Colour.ProductColours.Select(c => new BaseDTO
                {
                    Id = c.Colour.Id,
                    Name = c.Colour.Name,
                }).ToList()
            };

            return responseModel;
        }

        public async Task AddAsync(ProductColourRequestModel model)
        {
            var product = await _productRepository.GetByNameAsync(model.ProductName);
            if (product == null)
                throw new Exception("Ürün bulunamadı.");

            var colour = await _colourRepository.GetByNameAsync(model.ColourName);
            if (colour == null)
                throw new Exception("Renk bulunamadı.");

            // Aynı ürün ve renk daha önce eşleştirilmiş mi?
            var allProductColours = await _productColourRepository.GetAllAsync();
            var isExist = allProductColours.Any(pc => pc.ProductId == product.Id && pc.ColourId == colour.Id);

            if (isExist)
                throw new Exception("Bu ürün-rengi eşlemesi zaten var.");

            var newProductColour = new ProductColour
            {
                ProductId = product.Id,
                ColourId = colour.Id,
                IsDelete = false
            };

            await _productColourRepository.AddAsync(newProductColour);
        }

       

        public async Task UpdateAsync(ProductColourRequestModel model)
        {
            var product = await _productRepository.GetByNameAsync(model.ProductName);
            if (product == null)
                throw new Exception("Ürün bulunamadı.");

            var colour = await _colourRepository.GetByNameAsync(model.ColourName);
            if (colour == null)
                throw new Exception("Renk bulunamadı.");

            var existing = await _productColourRepository.GetByIdAsync(product.Id);
            if (existing == null)
                throw new Exception("Ürün rengi bulunamadı.");

            existing.ColourId = colour.Id;
            await _productColourRepository.UpdateAsync(existing);
        }


        public async Task DeleteAsync(int id)
        {
            var exististing = await _productColourRepository.GetByIdAsync(id);
            if (exististing == null)
                throw new Exception("Silinecek ürün rengi bulunamadı.");

            await _productColourRepository.DeleteAsync(id);
        }
    }
        

       
    
}
