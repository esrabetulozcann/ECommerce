using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.User;
using ECommerce.Core.Models.Response.Orders;
using ECommerce.Core.Models.Response.Users;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;
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
            var result = await _orderRepository.GetAllOrdersAsync();
            List<OrdersResponseModel> orderResponseModels = new List<OrdersResponseModel>();
            orderResponseModels = result.Select(o => new OrdersResponseModel
            {
                Id = o.Id,
                UserId = o.UserId,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                AddressId = o.AddressId,
                Status = o.Status,
                Users = new UserRequestModel
                {
                    Id = o.User.Id,
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName
                }

            }).ToList();
            return orderResponseModels;
        }



        public async Task<OrdersResponseModel> GetOrderByIdAsync(int id)
        {
            var result = await _orderRepository.GetOrderByIdAsync(id);
            if (result == null)
            {
                return new OrdersResponseModel();

            }
            else
            {

                OrdersResponseModel ordersResponseModel = new OrdersResponseModel
                {
                    Id = result.Id,
                    UserId = result.UserId,
                    OrderDate = result.OrderDate,
                    TotalPrice = result.TotalPrice,
                    AddressId = result.AddressId,
                    Status = result.Status,
                    Users = new UserRequestModel
                    {
                        Id = result.User.Id,
                        FirstName = result.User.FirstName,
                        LastName = result.User.LastName
                    }
                };

                return ordersResponseModel;
            }

        }

        public async Task<List<OrdersResponseModel>> GetByUserIdAsync(int userId)
        {
            var result = await _orderRepository.GetByUserIdAsync(userId);

            var filteredOrders = result
        .Where(o => o.UserId == userId)
        .Select(o => new OrdersResponseModel
        {
            Id = o.Id,
            UserId = o.UserId,
            OrderDate = o.OrderDate,
            TotalPrice = o.TotalPrice,
            AddressId = o.AddressId,
            Status = o.Status,
            Users = new UserRequestModel
            {
                Id = o.User.Id,
                FirstName = o.User.FirstName,
                LastName = o.User.LastName
            }
        }).ToList();

            return filteredOrders;
        }

        public async Task AddAsync(Order order)
        {
            var existing = await _orderRepository.GetOrderByIdAsync(order.Id);
            if (existing != null)
                throw new Exception("Bu id de bir sipariş mevcut.");

            await _orderRepository.AddAsync(order);
        }
    }
}
