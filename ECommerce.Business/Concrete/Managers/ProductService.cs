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
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       
        public async Task<List<ProductResponseModel>> GetAllAsync()
        {
            var result = await _productRepository.GetAllAsync();
            List<ProductResponseModel> responseModels = new List<ProductResponseModel>();
            responseModels = result.Select(p => new ProductResponseModel
            {
                Id = p.Id,
                Name = p.Name,
                Barcode = p.Barcode,
                Brand = p.Brand,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,

                Category = p.Category == null ? null : new CategoryResponseModel
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                },

                Colours = p.ProductColours?.Select(pc => new BaseDTO
                {
                    Id = pc.Colour.Id,
                    Name = pc.Colour.Name
                }).ToList(),

                Sizes = p.ProductSizes?.Select(ps => new BaseDTO
                { 
                        Id = ps.Size.Id,
                        Name = ps.Size.Name
                    
                }).ToList()

            }).ToList();
            return responseModels;
        }

        public async Task<List<ProductResponseModel>> GetByCategoryIdAsync(int categoryId)
        {
            var result = await _productRepository.GetByCategoryIdAsync(categoryId);
            List<ProductResponseModel> responseModels = new List<ProductResponseModel>();
            responseModels = result.Select(p => new ProductResponseModel
            {
                Id = p.Id,
                Name = p.Name,
                Barcode = p.Barcode,
                Brand = p.Brand,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,

            }).ToList();
            return responseModels;
        }

        public async Task<ProductResponseModel> GetByIdAsync(int id)
        {
            var result = await _productRepository.GetByIdAsync(id);
            if (result == null)
            {
                return new ProductResponseModel();
            }
            else
            {
                ProductResponseModel responseModel = new ProductResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Barcode = result.Barcode,
                    Brand = result.Brand,
                    
                    Description = result.Description,
                    Price = result.Price,
                    Quantity = result.Quantity,

                    Category = new CategoryResponseModel
                    {
                        Id = result.Category.Id,
                        Name = result.Category.Name,
                        
                    },

                    Colours = result.ProductColours?.Select(pc => new BaseDTO
                    {
                        Id = pc.Colour.Id,
                        Name = pc.Colour.Name
                    }).ToList(),

                    Sizes = result.ProductSizes?.Select(pc => new BaseDTO
                    {
                        Id = pc.Size.Id,
                        Name = pc.Size.Name,
    

                    }).ToList(),
                    
                };
                return responseModel;
            }
        }

        public async Task<ProductResponseModel> GetByNameAsync(string name)
        {
            var result = await _productRepository.GetByNameAsync(name);
            if(result == null)
            {
                return new ProductResponseModel();
            }
            else
            {
                ProductResponseModel responseModel = new ProductResponseModel
                {
                    Name = result.Name,
                    Id = result.Id,
                    Barcode = result.Barcode,
                    Brand = result.Brand,
                    Description = result.Description,
                    Price = result.Price,
                    Quantity = result.Quantity,
                    Category = new CategoryResponseModel
                    {
                        Id = result.Category.Id,
                        Name = result.Category.Name,
                        
                    },

                    Colours = result.ProductColours?.Select(pc => new BaseDTO
                    {
                        Id = pc.Colour.Id,
                        Name = pc.Colour.Name
                    }).ToList(),

                    Sizes = result.ProductSizes?.Select(pc => new BaseDTO
                    {
                        Id = pc.Size.Id,
                        Name = pc.Size.Name
                    }).ToList(),

                };
                return responseModel;
            }
        }

        public async Task<List<ProductResponseModel>> SearchAsync(string keyword)
        {
            var products = await _productRepository.SearchAsync(keyword);

            var response = products.Select(p => new ProductResponseModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                Barcode = p.Barcode,
                Brand = p.Brand,

                Category = new CategoryResponseModel
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name,
                    
                },

                Colours = p.ProductColours?.Select(pc => new BaseDTO
                {
                    Id = pc.Colour.Id,
                    Name = pc.Colour.Name
                }).ToList(),

                Sizes = p.ProductSizes?.Select(pc => new BaseDTO
                {
                    Id = pc.Size.Id,
                    Name = pc.Size.Name
                }).ToList(),
            }).ToList();

            return response;
        }

        public async Task AddAsync(Product product)
        {
            var existing = await _productRepository.GetByNameAsync(product.Barcode);
            if(existing != null)
                throw new Exception("Bu barkod da bir ürün zaten mevcut.");

            await _productRepository.AddAsync(existing);
        }

        public async Task UpdateAsync(Product product)
        {
            var existing = await _productRepository.GetByIdAsync(product.Id);
            if (existing != null)
                throw new Exception("Güncellenecek ürün bulunamadı");

            existing.Name = product.Name;

            await _productRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing != null)
                throw new Exception("Silinecek beden bulunamadı");

            await _productRepository.DeleteAsync(id);
        }


    }
}
