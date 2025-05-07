using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Invoice;
using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class InvoiceService : IInvoiceService
    { 
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository, IOrdersRepository ordersRepository, IOrderItemRepository orderItemRepository)
        {
            _invoiceRepository = invoiceRepository;
            _ordersRepository = ordersRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<List<InvoiceResponseModel>> GetAllAsync()
        {
            var result = await _invoiceRepository.GetAllAsync();
            List<InvoiceResponseModel> list = new List<InvoiceResponseModel>();
            list = result.Select(x => new InvoiceResponseModel
            {
                Id = x.Id,
                OrderId = x.OrderId,
                AddressId = x.AddressId,
                CargoFichNo = x.CargoFichNo,
                Date = x.Date,
                TotalPrice = x.TotalPrice,
            }).ToList();

            return list;
        }

        public async Task<InvoiceResponseModel> GetByIdAsync(int id)
        {
            var result = await _invoiceRepository.GetByIdAsync(id);
            if (result == null)
            {
                return new InvoiceResponseModel();
            }
            else
            {
                InvoiceResponseModel invoiceResponseModel = new InvoiceResponseModel
                {
                    Id = result.Id,
                    OrderId = result.OrderId,
                    AddressId = result.AddressId,
                    CargoFichNo = result.CargoFichNo,
                    Date = result.Date,
                    TotalPrice = result.TotalPrice,
                };

                return invoiceResponseModel;
            }
                


        }

        public async Task<InvoiceOrderDetailResponseModel> GetByOrderIdAsync(int orderId)
        {
            var order = await _ordersRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return new InvoiceOrderDetailResponseModel(); // ya da null dönebilirsin
            }

            var orderItems = await _orderItemRepository.GetByOrderIdAsync(orderId);

            var products = orderItems.Select(item => new InvoiceProductDetailResponseModel
            {
                ProductName = item.Product.Name, // Navigation property ile gelmeli (Include unutma!)
                Quantity = item.Quantity,
                UnitPrice = item.Price,
                LineTotal = item.Quantity * item.Price
            }).ToList();

            return new InvoiceOrderDetailResponseModel
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Products = products
            };

        }
    }
}
