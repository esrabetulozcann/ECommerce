using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.Country;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICountryService
    {
        Task<List<BaseDTO>> GetAllAsync();

        Task<BaseDTO> GetByIdAsync(int id);
        Task<BaseDTO> GetByNameAsync(string name);
        Task AddAsync(Country country);
        Task<List<CountryResponseModel>> GetAllWithCities();
    }
}
