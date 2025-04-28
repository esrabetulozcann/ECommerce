using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.OrderItem;
using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<List<AllOrderItemRequestModel>> GetAllAsync()
        {
            var result = await _orderItemRepository.GetAllAsync();
            List<AllOrderItemRequestModel> orderItemRequestModels = new List<AllOrderItemRequestModel>();
            orderItemRequestModels = result.Select(x => new AllOrderItemRequestModel
            {
                Id = x.Id,
                OrderId = x.OrderId,
                Price = x.Price,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }).ToList();

            return orderItemRequestModels;
        }

        public async Task<AllOrderItemRequestModel> GetByIdAsync(int id)
        {
            var result = await _orderItemRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new AllOrderItemRequestModel();
            }
            else
            {
                AllOrderItemRequestModel orderItemRequestModel = new AllOrderItemRequestModel
                {
                    Id = id,
                    OrderId= result.OrderId,
                    Price = result.Price,
                    ProductId = result.ProductId,
                    Quantity = result.Quantity,
                };
                return orderItemRequestModel;
            }
            
        }

        public async Task<OrderItemRequestModel> GetByOrderIdAsync(int id)
        {
            var result = await _orderItemRepository.GetByOrderIdAsync(id);
            if (result == null)
            {
                return new OrderItemRequestModel();
            }
            else
            {
                OrderItemRequestModel orderItemRequestModel = new OrderItemRequestModel
                {
                    OrderId = result.OrderId,
                    Price = result.Price,
                    ProductId = result.ProductId,
                    Quantity = result.Quantity
                };

                return orderItemRequestModel;
            }
        }
    }
}
