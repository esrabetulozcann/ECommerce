using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IProductSizeRepository
    {
        Task<List<Size>> GetSizesByProductIdAsync(int productId); // Bir ürünün sahip olduğu tüm bedenleri getirir.
        Task<List<Product>> GetProductsBySizeIdAsync(int sizeId); // Belirli bir bedenle ilişkili tüm ürünleri getirir. 
        Task AddAsync(ProductSize productSize); // Yeni bir ürün-beden ilişkisi ekler.
        Task RemoveAsync(ProductSize productSize); // Var olan ilişkiyi kaldırır.
        Task<bool> ExistsAsync(int productId, int sizeId); // Bu ürün ile bu beden zaten eşleştirilmiş mi?
    }
}
