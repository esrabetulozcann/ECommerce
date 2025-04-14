using ECommerce.Core.Models.Response.Sizes;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ISizeTypeService
    {
        Task<List<SizeTypeResponseModel>> GetAllAsync();
        Task<SizeTypeResponseModel> GetByIdAsync(int id); // ID'ye göre beden getirir
        Task<SizeTypeResponseModel> GetByNameAsync(string name); // İsme göre beden getirir (örneğin: "M", "L", "XL")
        
    }
}
