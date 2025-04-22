using ECommerce.Core.Models.Response.City;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City> GetByIdAsync(int id);
        Task<City> GetByNameAsync(string name);

        Task<List<City>> GetAllWithTown();
        Task AddAsync(City city);
    }
}
