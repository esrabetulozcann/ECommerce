using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
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
    public class ProductImageService : IProductImageService
    {
        private IProductImagesRepository _productImagesRepository;

        public ProductImageService(IProductImagesRepository productImagesRepository)
        {
            _productImagesRepository = productImagesRepository;
        }


        public async Task<List<ProductImagesResponseModel>> GetAllImagesAsync()
        {
            var result = await _productImagesRepository.GetAllImagesAsync();
            List<ProductImagesResponseModel> responseModels = new List<ProductImagesResponseModel>();
            responseModels = result.Select(pi => new ProductImagesResponseModel
            {
                Id = pi.Id,
                ImageUrl = pi.ImageUrl,
                IsDelete = pi.IsDelete,
                ProductId = pi.ProductId,
                Products = new BaseDTO
                {
                    Id = pi.Product.Id,
                    Name = pi.Product.Name,
                }
                    

            }).ToList();
            return responseModels;
        }

        public async Task<ProductImagesResponseModel> GetImagesByProductIdAsync(int id)
        {
            var result =  await _productImagesRepository.GetImagesByProductIdAsync(id);

            var responsModel = new ProductImagesResponseModel
            {
                Id = result.Id,
                ImageUrl = result.ImageUrl,
                IsDelete = result.IsDelete,
                ProductId = result.ProductId,
                Products = new BaseDTO
                {
                    Id = result.Product.Id,
                    Name =result.Product.Name,
                }
            };

            return responsModel;
            
        }


        public async Task AddAsync(ProductImage productImage)
        {
            var exististing = await _productImagesRepository.GetImagesByProductIdAsync(productImage.Id);
            if (exististing != null)
                throw new Exception("Bu id de bir ürün resmi mevcut");

            await _productImagesRepository.AddAsync(exististing);
            
        }

       
        public async Task UpdateAsync(ProductImage productImage)
        {
            var existing = await _productImagesRepository.GetImagesByProductIdAsync(productImage.Id);
            if (existing != null)
                throw new Exception("Güncellenecek ürün resmi bulunamadı");

            existing.ImageUrl = productImage.ImageUrl;

            await _productImagesRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _productImagesRepository.GetImagesByProductIdAsync(id);
            if (existing == null)
                throw new Exception("Silinecek ürün görseli bulunamadı");
            await _productImagesRepository.DeleteAsync(id);
        }
    }
}
