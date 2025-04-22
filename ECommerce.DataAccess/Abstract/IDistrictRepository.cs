using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IDistrictRepository
    {
        Task<List<District>> GetAllAsync();
        Task<District> GetByIdAsync(int id);
        Task<District> GetByNameAsync(string name);
        Task AddAsync(District district);
    }
}
