using ECommerce.Core.Models.Request.OrderItem;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IOrderItemService
    {
        Task<List<AllOrderItemRequestModel>> GetAllAsync();
        Task<AllOrderItemRequestModel> GetByIdAsync(int id);
        Task<List<OrderItemRequestModel>> GetByOrderIdAsync(int id);
    }
}
