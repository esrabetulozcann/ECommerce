using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ISizeTypeRepository
    {
        Task<List<Size>> GetAllAsync();
        Task<Size> GetByIdAsync(int id); // ID'ye göre beden getirir
        Task<Size> GetByNameAsync(string name); // İsme göre beden getirir (örneğin: "M", "L", "XL")
        Task AddAsync(Size size); // Yeni beden ekler
        Task UpdateAsync(Size size); // Var olan bedeni günceller
        Task DeleteAsync(int id); // Beden siler

    }
}
