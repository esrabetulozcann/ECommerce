using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int id);
        Task<Country> GetByNameAsync(string name);
        Task AddAsync(Country country);

        Task<List<Country>> GetAllWithCities();
    }
}
