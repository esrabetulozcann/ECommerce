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

        /*public async Task<List<ProductColourResponseModel>> GetAllAsync()
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
        */


        public async Task<List<ProductColourResponseModel>> GetAllAsync()
        {
            var result = await _productColourRepository.GetAllAsync();
            List<ProductColourResponseModel> responseModels = new List<ProductColourResponseModel>();

            responseModels = result.Select(x => new ProductColourResponseModel
            {
                Id = x.Id,
                ColourId = x.ColourId,
                ProductId = x.ProductId,
                Name = $"{x.Product?.Name} - {x.Colour?.Name}", // Örnek birleşik ad

                // Burada ProductResponseModel'in bir liste yerine tek bir nesne olması gerektiği için List<ProductResponseModel> değil, sadece bir nesne atanıyor
                Products = x.Product != null
                    ? new ProductResponseModel
                    {
                        Id = x.Product.Id,
                        Name = x.Product.Name,
                        Barcode = x.Product.Barcode,
                        Brand = x.Product.Brand,
                       
                        Description = x.Product.Description,
                        Quantity = x.Product.Quantity,
                        Price = x.Product.Price,
                    }
                    : null, // null yapıyoruz çünkü ürün olmayabilir

                // Burada da ColourResponseModel'in bir liste yerine tek bir nesne olması gerektiği için List<ColourResponseModel> değil, sadece bir nesne atanıyor
                Colours = x.Colour != null
                    ? new ColourResponseModel
                    {
                        Id = x.Colour.Id,
                        Name = x.Colour.Name,
                        ProductColurId = x.Id
                    }
                    : null // null yapıyoruz çünkü renk olmayabilir
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
                    Products = new ProductResponseModel
                    {
                        Id = result.Product.Id,
                        Name = result.Product.Name,
                    },
                    Colours = new ColourResponseModel
                    {
                        Id = result.Colour.Id,
                        Name = result.Colour.Name,
                    }
                };
                return responseModel;
            }
        }
        public async Task<ColourResponseModel> GetByColourIdAsync(int id)
        {
            var result = await _productColourRepository.GetByColourIdAsync(id);
            if (result == null)
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
            if (result == null)
            {
                return new ProductResponseModel();
            }
            else
            {
                return new ProductResponseModel
                {
                    Id = result.Id,
                    Barcode = result.Barcode,
                    Brand = result.Brand,
                    
                    Name = result.Name,
                    Description = result.Description,
                    Quantity = result.Quantity,
                    Price = result.Price,

                    Category = result.Category != null
                    ? new CategoryResponseModel
                    {
                        Id = result.Category.Id,
                        Name = result.Category.Name
                    }
                    : null,

                    Colours = result.ProductColours?
                    .Select(pc => new BaseDTO
                    {
                        Id = pc.Colour.Id,
                        Name = pc.Colour.Name,
                       
                    }).ToList(), // Burada ProductColourResponseModel bir liste olarak döndürüyoruz

                    Sizes = result.ProductSizes?
                    .Select(ps => new BaseDTO
                    {

                        Id = ps.Size.Id,
                        Name = ps.Size.Name,
                        
                    }).ToList() // Burada ProductSizeResponseModel bir liste olarak döndürüyoruz
                };
            }
        }
    }
}
