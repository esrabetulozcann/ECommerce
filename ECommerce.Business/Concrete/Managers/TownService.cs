using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.Town;
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
    public class TownService : ITownService
    {
        private readonly ITownRepository _townRepository;
        public TownService(ITownRepository townRepository)
        {
            _townRepository = townRepository;
        }

        public async Task AddAsync(Town town)
        {
            var existing = await _townRepository.GetByNameAsync(town.Name);
            if (existing != null)
                throw new Exception("Bu isimde bir ilçe var.");

            await _townRepository.AddAsync(town);
        }

        public async Task<List<BaseDTO>> GetAllAsync()
        {
            var result = await _townRepository.GetAllAsync();
            List<BaseDTO> responseModels = new List<BaseDTO>();
            responseModels = result.Select(x => new BaseDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return responseModels;
        }

       

        public async Task<BaseDTO> GetByIdAsync(int id)
        {
            var result = await _townRepository.GetByIdAsync(id);
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
            var result = await _townRepository.GetByNameAsync(name);
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

        public async Task<List<TownWithDistrictRequestModel>> GetAllWithDistrict()
        {
            var result = await _townRepository.GetAllWithDistrict();
            List<TownWithDistrictRequestModel> responseModels = new List<TownWithDistrictRequestModel>();

            responseModels = result.Select(t => new TownWithDistrictRequestModel
            {
                Id = t.Id,
                Name = t.Name,
                District = t.Districts.Select(td => new BaseDTO
                {
                    Id = td.Id,
                    Name = td.Name,
                }).ToList(),
            }).ToList();

            return responseModels;
        }
    }
}
