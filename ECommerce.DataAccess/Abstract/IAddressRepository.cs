using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAsync();
        Task<List<Address>> GetAllActiveAsync(); // sadece aktif (silinmemiş) adresler
        Task<Address> GetByIdAsync(int id);
        Task<List<Address>> GetByUserIdAsync(int userId);
        Task AddAsync(Address address);
        Task UpdateAsync(Address address);
        Task DeleteAsync(int id);

    }
}
