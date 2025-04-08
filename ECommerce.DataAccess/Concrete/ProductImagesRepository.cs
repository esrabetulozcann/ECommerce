using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class ProductImagesRepository : IProductImagesRepository
    {
        private EcommerceContext _context;
        public ProductImagesRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<List<ProductImagesResponseModel>> GetAllImagesAsync()
        {
            return await _context.ProductImages
                 .Select(pi => new ProductImagesResponseModel
                 {
                     Id = pi.Id,
                     ProductId = pi.ProductId,
                     ImageUrl = pi.ImageUrl
                 }).ToListAsync();
        }

        public async Task<List<ProductImagesResponseModel>> GetImagesByProductIdAsync(int productId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductId == productId)
                .Select(pi => new ProductImagesResponseModel
                {
                    Id = pi.Id,
                    ProductId = pi.ProductId,
                    ImageUrl = pi.ImageUrl
                }).ToListAsync();
        }
    }
}
