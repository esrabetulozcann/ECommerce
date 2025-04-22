using ECommerce.Core.Models.DTO;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IDistrictService
    {
        Task<List<BaseDTO>> GetAllAsync();
        Task<BaseDTO> GetByIdAsync(int id);
        Task<BaseDTO> GetByNameAsync(string name);
        Task AddAsync(District district);
    }
}
