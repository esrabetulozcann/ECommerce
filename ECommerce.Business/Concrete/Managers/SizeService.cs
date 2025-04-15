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
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }


        public async Task<List<SizeResponseModel>> GetAllAsync()
        {
            var result = await _sizeRepository.GetAllAsync();
            List<SizeResponseModel> responseModels = new List<SizeResponseModel>();
            responseModels = result.Select(s => new SizeResponseModel
            {
                Id = s.Id,
                Name = s.Name,
                SizeTypeId = s.SizeTypeId,
                SizeType = new SizeTypeResponseModel
                {
                    Id = s.SizeType.Id,
                    Name = s.SizeType.Name,
                }
            }).ToList();
            return responseModels;
        }

        public async Task<SizeResponseModel> GetByIdAsync(int id)
        {
            var result = await _sizeRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new SizeResponseModel();
            }
            else
            {
                SizeResponseModel responseModel = new SizeResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    SizeTypeId = result.SizeTypeId,
                    SizeType = new SizeTypeResponseModel
                    {
                        Id = result.Id,
                        Name = result.Name,
                    }
                };
                return responseModel;
            }
        }

        public async Task<SizeResponseModel> GetByNameAsync(string name)
        {
            var result = await _sizeRepository.GetByNameAsync(name);
            if (result == null)
            {
                return new SizeResponseModel();
            }
            else
            {
                SizeResponseModel responseModel = new SizeResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    SizeTypeId = result.SizeTypeId,
                    SizeType = new SizeTypeResponseModel
                    {
                        Id = result.Id,
                        Name = result.Name,
                    }
                };
                return responseModel;
            }
        }

        public async Task<SizeTypeResponseModel> GetBySizeTypeIdAsync(int id)
        {
            var result = await _sizeRepository.GetBySizeTypeIdAsync(id);
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
        public async Task AddAsync(Size size)
        {
            // Örnek validation: Aynı isimde beden var mı kontrolü
            var existing = await _sizeRepository.GetByNameAsync(size.Name);
            if (existing != null)
                throw new Exception("Bu isimde bir beden zaten mevcut.");

            await _sizeRepository.AddAsync(size);
        }

        public async Task UpdateAsync(Size size)
        {
            var existing = await _sizeRepository.GetByIdAsync(size.Id);
            if (existing == null)
                throw new Exception("Güncellenecek beden bulunamadı.");

            // İstersen burada property'leri tek tek atayabilirsin:
            existing.Name = size.Name;
            // diğer alanlar varsa onları da güncelle

            await _sizeRepository.UpdateAsync(existing);
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _sizeRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Silinecek beden bulunamadı.");

            await _sizeRepository.DeleteAsync(id);
        }

        
    }
}
