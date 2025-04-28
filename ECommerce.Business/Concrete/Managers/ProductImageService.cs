using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.ProductImage;
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
        private IProductRepository _productRepository;

        public ProductImageService(IProductImagesRepository productImagesRepository, IProductRepository productRepository)
        {
            _productImagesRepository = productImagesRepository;
            _productRepository = productRepository;
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


        public async Task AddAsync(ProductImageRequestModel model)
        {
            var productName = await _productRepository.GetByNameAsync(model.ProductName);
            if (productName == null)
                throw new Exception("Ürün bulunamadı");

            var productImage = await _productImagesRepository.GetByImageUrlAsync(model.ImageUrl);
            if (productImage != null)
                throw new Exception("Ürün görsel daha önce eklenmiş.");


            var newImage = new ProductImage
            {
                ProductId = productName.Id,
                ImageUrl = model.ImageUrl
            };

            await _productImagesRepository.AddAsync(newImage);
            
        }

       
        public async Task UpdateAsync(ProductImageRequestModel model)
        {
            var product = await _productRepository.GetByNameAsync(model.ProductName);
            if (product == null)
                throw new Exception("Ürün bulunamadı");

            // Ürüne ait eski görseli getirdim
            var productImage = await _productImagesRepository.GetImagesByProductIdAsync(product.Id);
            if (productImage == null)
                throw new Exception("Güncellenecek ürün görseli bulunamadı");

            // Yeni ürünü atadım
           productImage.ImageUrl = model.ImageUrl;

            await _productImagesRepository.UpdateAsync(productImage);
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
