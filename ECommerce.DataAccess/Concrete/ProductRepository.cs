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
    public class ProductRepository : IProductRepository
    {
        private EcommerceContext _context; // ECommerce dekileri getirdim.
        public ProductRepository(EcommerceContext context)
        {
            _context = context;
        }

       
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); // Tüm ürünleri listeledim
        }


        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id); // Id ye göre listeledim

        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Name == name); // Name e göre listeledim.
        }

       
        public async Task AddAsync(Product product) // Ürürn ekleme işlmei gerçekleştirdim.
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product) // Ürürn güncelleme işlemi gerçekleştirdim.
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public  async Task DeleteAsync(int id) // Ürürn silme işlemi gerçekleştirdim.
        {
            var product = await _context.Products.FindAsync(id);
            if( product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetByCategoryIdAsync(int categoryId) // Category id sine göre listeledim.
        {
            return await _context.Products
                .Where( p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<Product>> SearchAsync(string keyword) // Arama ismine göre listeledim
        {
            return await _context.Products
                .Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword))
                .ToListAsync();
        }

       
    }
}
