using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ISizeRepository
    {
        Task<List<Size>> GetAllAsync(); // Tüm bedenleri getirir
        Task<Size> GetByIdAsync(int id); // ID'ye göre beden getirir
        Task<Size> GetByNameAsync(string name); // İsme göre beden getirir (örneğin: "M", "L", "XL")
        Task<SizeType> GetBySizeTypeIdAsync(int id);
        Task AddAsync(Size size);
        Task UpdateAsync(Size size);
        Task DeleteAsync(int id);

    
    }
}
