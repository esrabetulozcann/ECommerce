using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Address;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        
        public async Task<List<AddressRequestModel>> GetAllActiveAsync()
        {
            var result = await _addressRepository.GetAllActiveAsync();
            List<AddressRequestModel> list = new List<AddressRequestModel>();
            
            list = result.Select(a => new AddressRequestModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AddressText = a.AddressText,
                CityId = a.CityId,
                CountryId = a.CountryId,
                DistrictId = a.DistrictId,
                IsDelete = a.IsDelete,
                PostalCode = a.PostalCode,
                TownId = a.TownId,
            }).ToList();

            return list;
        }

        public async Task<List<AddressRequestModel>> GetAllAsync()
        {
           var result = await _addressRepository.GetAllAsync();
            List<AddressRequestModel> addressRequestModels = new List<AddressRequestModel>();
            addressRequestModels = result.Select(a => new AddressRequestModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AddressText = a.AddressText,
                CityId = a.CityId,
                CountryId = a.CountryId,
                DistrictId = a.DistrictId,
                IsDelete = a.IsDelete,
                PostalCode = a.PostalCode,
                TownId = a.TownId,
            }).ToList();

            return addressRequestModels;
        }

        public async Task<AddressRequestModel> GetByIdAsync(int id)
        {
            var result = await _addressRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new AddressRequestModel();
            }
            else
            {
                AddressRequestModel addressRequestModel = new AddressRequestModel
                {
                    Id = result.Id,
                    UserId = result.UserId,
                    AddressText = result.AddressText,
                    CityId = result.CityId,
                    CountryId = result.CountryId,
                    DistrictId = result.DistrictId,
                    IsDelete = result.IsDelete,
                    PostalCode = result.PostalCode,
                    TownId = result.TownId,

                };
                return addressRequestModel;
            }
        }

        public async Task<List<AddressRequestModel>> GetByUserIdAsync(int userId) //Sadece kullanıcının silinmemiş yani aktif olan adreslerini döndürür.
        {
           var result = await _addressRepository.GetByUserIdAsync(userId);
            List<AddressRequestModel> addressRequestModels = new List<AddressRequestModel>();

            addressRequestModels = result.Select(x => new AddressRequestModel
            {
                Id = x.Id,
                UserId = x.UserId,
                AddressText = x.AddressText,
                CityId = x.CityId,
                CountryId = x.CountryId,
                DistrictId = x.DistrictId,
                IsDelete = x.IsDelete,
                PostalCode = x.PostalCode,
                TownId = x.TownId,
            }).ToList();

            return addressRequestModels;
            
        }


        public async Task AddAsync(AddressAddRequestModel addressAddRequest)
        {
            var existing = await _addressRepository.GetByUserIdAsync(addressAddRequest.UserId);

            // Aynı adresten var mı kontrolü:
            bool sameAddressExists = existing.Any(x =>
                x.AddressText == addressAddRequest.AddressText &&
                x.CityId == addressAddRequest.CityId &&
                x.CountryId == addressAddRequest.CountryId &&
                x.DistrictId == addressAddRequest.DistrictId &&
                x.TownId == addressAddRequest.TownId &&
                x.PostalCode == addressAddRequest.PostalCode &&
                !x.IsDelete // sadece silinmemiş adresler dikkate alınsın
            );

            if (sameAddressExists)
                throw new Exception("Bu adres zaten sistemde kayıtlı.");


            var newAddress = new Address
            {
                UserId = addressAddRequest.UserId,
                AddressText = addressAddRequest.AddressText,
                CityId = addressAddRequest.CityId,
                CountryId = addressAddRequest.CountryId,
                DistrictId = addressAddRequest.DistrictId,
                PostalCode = addressAddRequest.PostalCode,
                TownId = addressAddRequest.TownId,

                
            };

            await _addressRepository.AddAsync(newAddress);
        }


        public async Task UpdateAsync(int addressId, int userId, AddressUpdateRequestModel model)
        {
            var existingAddress = await _addressRepository.GetByIdAsync(addressId);
            if (existingAddress == null)
                throw new Exception("Adres bulunamadı.");

            if (existingAddress.UserId != userId)
                throw new Exception("Bu adrese erişim yetkiniz yok.");

            // Sadece adres bilgilerinin güncellenmesi
            existingAddress.AddressText = model.AddressText;
            existingAddress.CityId = model.CityId;
            existingAddress.CountryId = model.CountryId;
            existingAddress.DistrictId = model.DistrictId;
            existingAddress.TownId = model.TownId;
            existingAddress.PostalCode = model.PostalCode;

            await _addressRepository.UpdateAsync(existingAddress);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _addressRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Silinecek adres bulunamadı");

            await _addressRepository.DeleteAsync(id);
        }

    }
}
