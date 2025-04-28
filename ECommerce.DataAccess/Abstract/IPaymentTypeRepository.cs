using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IPaymentTypeRepository
    {
        Task<List<PaymetnType>> GetAllAsync();
        Task<PaymetnType> GetByIdAsync(int id);
        Task<PaymetnType> GetByNameAsync(string name);  

    }
}
