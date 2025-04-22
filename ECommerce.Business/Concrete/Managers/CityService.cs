using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.City;
using ECommerce.Core.Models.Response.City;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;   
        }

        public async Task AddAsync(City city)
        {
            var existing = await _cityRepository.GetByNameAsync(city.Name);
            if (existing != null)
                throw new Exception("Bu isimde bir şehir var.");

            await _cityRepository.AddAsync(city);
        }

        public async Task<List<CityResponseModel>> GetAllAsync()
        {
           var result = await _cityRepository.GetAllAsync();
            List<CityResponseModel> responseModels = new List<CityResponseModel>();

            responseModels = result.Select(c => new CityResponseModel
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
            return responseModels;
        }

        public async Task<List<CityWithTownRequestModel>> GetAllWithTown()
        {
            var result = await _cityRepository.GetAllWithTown();
            List<CityWithTownRequestModel> responseModels = new List<CityWithTownRequestModel>();

            responseModels = result.Select(c => new CityWithTownRequestModel
            {
                Id = c.Id,
                Name = c.Name,
                Town = c.Towns.Select(t => new BaseDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToList(),
                
            }).ToList();

            return responseModels;

        }

        public async Task<CityResponseModel> GetByIdAsync(int id)
        {
            var result = await _cityRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new CityResponseModel();
            }
            else
            {
                CityResponseModel cityResponseModel = new CityResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                };

                return cityResponseModel;
            }
        }

        public async Task<CityResponseModel> GetByNameAsync(string name)
        {
            var result = await _cityRepository.GetByNameAsync(name);
            if( result == null)
            {
                return new CityResponseModel();
            }
            else
            {
                CityResponseModel cityResponseModel = new CityResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                };
                return cityResponseModel;
            }
        }
    }
}
