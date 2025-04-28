using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.Order;
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
        private IOrderItemRepository _orderItemRepository;
        private IProductRepository _productRepository;

        public OrdersService(IOrdersRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
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

        
        public async Task AddAsync(OrderAddRequestModel order)
        {
            var newOrder = new Order
            {
                UserId = order.UserId,
                AddressId = order.AddressId,
                OrderDate = DateTime.Now, // Şu anki tarih
                Status = false, // Yeni eklenen sipariş için başlangıç durumu
            };
            var orderId = await _orderRepository.AddAsync(newOrder);
            decimal totalPrice = 0;

            foreach (var item in order.OrderItems)
            {
                // Burada ürünün fiyatını veri tabanından çekiyoruz
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product == null)
                    throw new Exception($"Product with ID {item.ProductId} not found!");

                var price = product.Price;

                totalPrice += price * item.Quantity;

                await _orderItemRepository.AddAsync(new OrderItem
                {
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price,
                });

                // Siparişin toplam fiyatını güncelliyoruz
                newOrder.TotalPrice = totalPrice;
                await _orderRepository.UpdateAsync(newOrder);
            }
        }



    }
}
