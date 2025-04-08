using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Orders;
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
        private OrderRepository _orderRepository;

        public OrdersService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrdersResponseModel>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<OrdersResponseModel> GetOrderBeyIdAsync(int id)
        {
            return await _orderRepository.GetOrderBeyIdAsync(id);
        }
    }
}
