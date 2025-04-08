using ECommerce.Core.Models.Response.Orders;
using ECommerce.Core.Models.Response.Users;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class OrderRepository : IOrdersRepository
    {
        private EcommerceContext _context;
        public OrderRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<List<OrdersResponseModel>> GetAllOrdersAsync()
        {
            return await _context.Orders
                 .Include(o => o.User)
                 .Include(o => o.OrderItems)
                 .Select(o => new OrdersResponseModel
                 {
                     Id = o.Id,
                     UserId = o.UserId,
                     Users = new List<UserResponseModel>
                     {
                        new UserResponseModel
                        {
                            Id = o.User.Id,
                            FirstName = o.User.FirstName,
                            LastName = o.User.LastName,
                            Email = o.User.Email
                        }
                     },
                     OrderDate = o.OrderDate,
                     TotalPrice = o.TotalPrice,
                     OrderItems = o.OrderItems.Select(oi => new OrderItemResponseModel
                     {
                         Id = oi.Id,
                         OrderId = oi.OrderId,
                         ProductId = oi.ProductId,
                         ProductName = oi.Product.Name,
                         Quantity = oi.Quantity,
                         UnitPrice = oi.UnitPrice
                     }).ToList()
                 })
                 .ToListAsync();
        }

        public async Task<UserResponseModel> GetByUserIdAsync(int id)
        {
            return await _context.Orders
                .Where(o => o.UserId == id)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.User)
                .Select(o => new OrdersResponseModel
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    Users = new List<UserResponseModel>
                    {
                        new UserResponseModel
                        {
                            Id = o.User.Id,
                            FirstName = o.User.FirstName,
                            LastName = o.User.LastName,
                            Email = o.User.Email
                        }
                    },
                    OrderDate = o.OrderDate,
                    TotalPrice = o.TotalPrice,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemResponseModel
                    {
                        Id = oi.Id,
                        OrderId = oi.OrderId,
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<OrdersResponseModel> GetOrderBeyIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return new OrdersResponseModel
            {
                Id = order.Id,
                UserId = order.UserId,
                Users = new List<UserResponseModel>
                {
                    new UserResponseModel
                    {
                        Id = order.User.Id,
                        FirstName = order.User.FirstName,
                        LastName = order.User.LastName,
                        Email = order.User.Email
                    }
                },
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                OrderItems = order.OrderItems.Select(oi => new OrderItemResponseModel
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };
        }
    }
}
