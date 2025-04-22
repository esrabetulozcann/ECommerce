using ECommerce.Core.Models.Request.City;
using ECommerce.Core.Models.Response.City;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICityService
    {
        Task<List<CityResponseModel>> GetAllAsync();
        Task<CityResponseModel> GetByIdAsync(int id);
        Task<CityResponseModel> GetByNameAsync(string name);
        Task<List<CityWithTownRequestModel>> GetAllWithTown();
        Task AddAsync(City city);
    }
}
