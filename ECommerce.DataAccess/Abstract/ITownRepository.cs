using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ITownRepository
    {
        Task<List<Town>> GetAllAsync();
        Task<Town> GetByIdAsync(int id);
        Task<Town> GetByNameAsync(string name);
        Task<List<Town>> GetAllWithDistrict();
        Task AddAsync(Town town);
    }
}
