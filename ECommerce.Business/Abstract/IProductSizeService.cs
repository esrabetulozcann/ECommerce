using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IProductSizeService
    {
        Task<List<Size>> GetSizesByProductIdAsync(int productId); // Bir ürünün sahip olduğu tüm bedenleri getirir.
        Task<List<Product>> GetProductsBySizeIdAsync(int sizeId); // Belirli bir bedenle ilişkili tüm ürünleri getirir. 
        Task AddAsync(int ProductId, int SizeId); // Yeni bir ürün-beden ilişkisi ekler.
        Task<bool> ExistsAsync(int productId, int sizeId); // Bu ürün ile bu beden zaten eşleştirilmiş mi?
    }
}
