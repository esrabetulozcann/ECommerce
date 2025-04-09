using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Orders;
using ECommerce.Core.Models.Response.Users;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class OrdersService : IOrdersService
    {
        private IOrdersRepository _orderRepository;

        public OrdersService(IOrdersRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrdersResponseModel>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public Task<UserResponseModel> GetByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrdersResponseModel> GetOrderBeyIdAsync(int id)
        {
            return await _orderRepository.GetOrderBeyIdAsync(id);
        }
    }
}
