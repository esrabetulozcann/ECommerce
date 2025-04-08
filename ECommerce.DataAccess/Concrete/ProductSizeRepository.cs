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
    public class ProductSizeRepository : IProductSizeRepository
    {
        private EcommerceContext _context;

        public ProductSizeRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsBySizeIdAsync(int sizeId)
        {
            return await _context.ProductSizes
                .Where(ps => ps.SizeId == sizeId)
                .Include(ps => ps.Product)
                .Select(ps => ps.Product)
                .ToListAsync();
        }

        public async Task<List<Size>> GetSizesByProductIdAsync(int productId)
        {
            return await _context.ProductSizes
                .Where(ps => ps.ProductId == productId)
                .Include(ps => ps.Size)
                .Select(ps => ps.Size)
                .ToListAsync();
        }

        public async Task AddAsync(ProductSize productSize)
        {
            await _context.ProductSizes.AddAsync(productSize);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(ProductSize productSize)
        {
            _context.ProductSizes.Remove(productSize);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> ExistsAsync(int productId, int sizeId)
        {
            return await _context.ProductSizes
                .AnyAsync(ps => ps.ProductId == productId && ps.SizeId == sizeId);
        }

        

       
    }
}
