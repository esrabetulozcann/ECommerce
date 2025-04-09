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
        private readonly IOrdersRepository _orderRepository;

        public OrdersService(IOrdersRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrdersResponseModel>> GetAllOrdersAsync()
        {
            var result = await _orderRepository.GetAllOrdersAsync();
            List<OrdersResponseModel> orderResponseModels = new List<OrdersResponseModel>();
            orderResponseModels = result.Select(o => new OrdersResponseModel
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                AddressId = o.AddressId,
                Status = o.Status,
            }).ToList();
            return orderResponseModels;
        }

        public async Task<UserResponseModel> GetByUserIdAsync(int id)
        {
            var result = await _orderRepository.GetByUserIdAsync(id);

            if(result == null)
            {
                return new UserResponseModel();
            }
            else
            {
                UserResponseModel userResponseModel = new UserResponseModel
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    BirthDate = result.BirthDate,
                    CreatedDate = result.CreatedDate,
                    Email = result.Email,
                    Gender = result.Gender,
                    Password = result.Password,
                    PhoneNumber1 = result.PhoneNumber1,
                    PhoneNumber2 = result.PhoneNumber2

                };
                return userResponseModel;
            }
        }

        public async Task<OrdersResponseModel> GetOrderBeyIdAsync(int id)
        {
            var result = await _orderRepository.GetOrderBeyIdAsync(id);
            if(result == null)
            {
                return new OrdersResponseModel();

            }
            else
            {

                OrdersResponseModel ordersResponseModel = new OrdersResponseModel
                {
                    Id = result.Id,
                    OrderDate = result.OrderDate,
                    TotalPrice = result.TotalPrice,
                    AddressId = result.AddressId,
                    Status = result.Status,

                };

                return ordersResponseModel;

                
            }

        }
    }
}
