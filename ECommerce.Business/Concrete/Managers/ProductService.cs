using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.Product;
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
        private ICategoryRepository _categoryRepository;
        private IColourRepository _colourRepository;
        private ISizeRepository _sizeRepository;
        public ProductService(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IColourRepository colourRepository,
            ISizeRepository sizeRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _colourRepository = colourRepository;
            _sizeRepository = sizeRepository;
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
                IsDelete = p.IsDelete,

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
                    IsDelete = result.IsDelete,

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
                    IsDelete = result.IsDelete,
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
                IsDelete= p.IsDelete,

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

        public async Task AddAsync(ProductRequestModel model)
        {
            var existing = await _productRepository.GetByNameAsync(model.Barcode);
            if (existing != null)
                throw new Exception("Bu barkodda bir ürün zaten mevcut.");

           

            // 4. Ürünü oluştur
            var newProduct = new ECommerce.DataAccess.Models.Product
            {
                Name = model.Name,
                Description = model.Description,
                Quantity = model.Quantity,
                Price = model.Price,
                Barcode = model.Barcode,
                Brand = model.Brand,
                IsDelete = false
            };

            await _productRepository.AddAsync(newProduct);


        }

        public async Task UpdateAsync(ProductRequestModel model, int id)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Güncellenecek ürün bulunamadı");


            // Güncelleme işlemi
            existing.Name = model.Name;
            existing.Description = model.Description;
            existing.Price = model.Price;
            existing.Quantity = model.Quantity;
            existing.Barcode = model.Barcode; // barcode değişmesini istiyorsan bunu da güncelleyebilirsin
            existing.Brand = model.Brand;
            

            await _productRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Silinecek beden bulunamadı");

            await _productRepository.DeleteAsync(id);
        }


    }
}
