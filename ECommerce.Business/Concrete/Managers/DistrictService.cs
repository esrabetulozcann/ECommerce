using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.District;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async Task AddAsync(District district)
        {
            var existing = await _districtRepository.GetByNameAsync(district.Name);
            if (existing != null)
                throw new Exception("Bu isimde bir mahalle var.");

            await _districtRepository.AddAsync(district);
        }

        public async Task<List<BaseDTO>> GetAllAsync()
        {
            var result = await _districtRepository.GetAllAsync();
            List<BaseDTO> responseModels = new List<BaseDTO>();

            responseModels = result.Select(d => new BaseDTO
            {
                Id = d.Id,
                Name = d.Name,
            }).ToList();

            return responseModels;

        }

        public async Task<BaseDTO> GetByIdAsync(int id)
        {
            var result = await _districtRepository.GetByIdAsync(id);
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

        public async Task<BaseDTO> GetByNameAsync(string name)
        {
            var result = await _districtRepository.GetByNameAsync(name);
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
    }
}
