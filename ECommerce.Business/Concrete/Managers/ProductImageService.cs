﻿using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
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
            var result = await _productImagesRepository.GetAllImagesAsync();
            List<ProductImagesResponseModel> responseModels = new List<ProductImagesResponseModel>();
            responseModels = result.Select(pi => new ProductImagesResponseModel
            {
                Id = pi.Id,
                ImageUrl = pi.ImageUrl,
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
            return null;
            
        }
    }
}
