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
         EcommerceContext _context;
        public ProductImagesRepository(EcommerceContext context)
        {
            _context = new();
        }

        

        public async Task<List<ProductImage>> GetAllImagesAsync()
        {
            return await _context.ProductImages.Include(pi => pi.Product).ToListAsync();
        }

        public async Task<ProductImage> GetImagesByProductIdAsync(int id)
        {
            return await _context.ProductImages
                .Include(pi => pi.Product)
                .FirstOrDefaultAsync(pi => pi.ProductId == id);
        }


        public async Task AddAsync(ProductImage productImage)
        {
            await _context.ProductImages.AddAsync(productImage);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(ProductImage productImage)
        {
            _context.ProductImages.Update(productImage);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var productImages = await _context.ProductImages.FindAsync(id);
            if(productImages != null)
            {
                productImages.IsDelete = true;
                _context.ProductImages.Update(productImages);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ProductImage> GetByImageUrlAsync(string imageUrl)
        {
            return await _context.ProductImages.FirstOrDefaultAsync(pi => pi.ImageUrl == imageUrl);
        }
    }
}
