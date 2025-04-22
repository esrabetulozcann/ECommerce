using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.City;
using ECommerce.Core.Models.Response.Country;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task AddAsync(Country country)
        {
            var existing = await _countryRepository.GetByNameAsync(country.Name);
            if (existing != null)
                throw new Exception("Bu isimde bir ülke var.");

            await _countryRepository.AddAsync(country);
        }

        public async Task<List<BaseDTO>> GetAllAsync()
        {
            var result = await _countryRepository.GetAllAsync();
            List<BaseDTO> responseModels = new List<BaseDTO>();
            responseModels = result.Select(c => new BaseDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return responseModels;
        }




        public async Task<BaseDTO> GetByIdAsync(int id)
        {
           var result = await _countryRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new BaseDTO();
            }
            else
            {
                 return new BaseDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                };
                
            }
        }

        public async Task<BaseDTO> GetByNameAsync(string name)
        {
            var result = await _countryRepository.GetByNameAsync(name);
            if (result == null)
            {
                return new BaseDTO();
            }
            else
            {
                return new BaseDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                };
               
            }
        }


        public async Task<List<CountryResponseModel>> GetAllWithCities()
        {
            var result = await _countryRepository.GetAllWithCities();
            List<CountryResponseModel> responseModels = new List<CountryResponseModel>();

            responseModels = result.Select(c => new CountryResponseModel
            {
                Id = c.Id,
                Name = c.Name,
                Cities = c.Cities.Select(c => new CityResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList(),
            }).ToList();


            return responseModels;
        }
    }
}
