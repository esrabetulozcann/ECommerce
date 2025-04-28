using ECommerce.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IPaymentTypeService
    {
        Task<List<BaseDTO>> GetAllAsync();
        Task<BaseDTO> GetByIdAsync(int id);
        Task<BaseDTO> GetByNameAsync(string name);
    }
}
