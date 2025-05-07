using ECommerce.Core.Models.Request.Address;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IAddressService
    {
        Task<List<AddressRequestModel>> GetAllAsync();
        Task<List<AddressRequestModel>> GetAllActiveAsync();
        Task<AddressRequestModel> GetByIdAsync(int id);
        Task<List<AddressRequestModel>> GetByUserIdAsync(int userId);
        Task AddAsync(AddressAddRequestModel addressAddRequest);
        Task UpdateAsync(int addressId, int userId, AddressUpdateRequestModel model);
        Task DeleteAsync(int id);
    }
}
