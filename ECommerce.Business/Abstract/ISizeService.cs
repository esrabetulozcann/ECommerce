using ECommerce.Core.Models.Response.Sizes;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ISizeService
    {
        Task<List<SizeResponseModel>> GetAllAsync(); // Tüm bedenleri getirir
        Task<SizeResponseModel> GetByIdAsync(int id); // ID'ye göre beden getirir
        Task<SizeResponseModel> GetByNameAsync(string name); // İsme göre beden getirir (örneğin: "M", "L", "XL")
        Task<SizeTypeResponseModel> GetBySizeTypeIdAsync(int id); // SizeType id sine göre getirecek.
        Task AddAsync(Size size); // Yeni beden ekler
        Task UpdateAsync(Size size); // Var olan bedeni günceller
        Task DeleteAsync(int id); // Beden siler
    }
}
