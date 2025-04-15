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

        public async Task<List<ProductImage>> GetImagesByProductIdAsync(int id)
        {
            return await _context.ProductImages.Include(pi => pi.Product).ToListAsync();
        }
    }
}
