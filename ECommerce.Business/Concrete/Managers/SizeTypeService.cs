using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Sizes;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class SizeTypeService : ISizeTypeService
    {
        private ISizeTypeRepository _sizeTypeRepository;
        public SizeTypeService(ISizeTypeRepository sizeTypeRepository)
        {
             _sizeTypeRepository = sizeTypeRepository;
        }

        

        public async Task<List<SizeTypeResponseModel>> GetAllAsync()
        {
            var result = await _sizeTypeRepository.GetAllAsync();
           List<SizeTypeResponseModel> responseModels = new List<SizeTypeResponseModel>();
            responseModels = result.Select(x => new SizeTypeResponseModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return responseModels;
            
        }

        public async Task<SizeTypeResponseModel> GetByIdAsync(int id)
        {
            var result = await _sizeTypeRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new SizeTypeResponseModel();
            }
            else
            {
                SizeTypeResponseModel responseModel = new SizeTypeResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                };

                return responseModel;
            }
        }

        public async Task<SizeTypeResponseModel> GetByNameAsync(string name)
        {
            var result = await _sizeTypeRepository.GetByNameAsync(name);
            if(result == null )
            {
                return new SizeTypeResponseModel();
            }
            else
            {
                SizeTypeResponseModel responseModel = new SizeTypeResponseModel
                {
                    Name = result.Name,
                    Id = result.Id,
                };
                return responseModel;
            }
        }

      
    }
}
