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
        Task<List<SizeType>> GetAllAsync();
        Task<SizeType> GetByIdAsync(int id); // ID'ye göre beden getirir
        Task<SizeType> GetByNameAsync(string name); // İsme göre beden getirir (örneğin: "M", "L", "XL")
     

    }
}
