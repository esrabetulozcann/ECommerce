using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Invoice;
using ECommerce.Core.Models.Response.InvoiceDetail;
using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class InvoiceDetailService :IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public async Task<List<InvoiceDetailResponseModel>> GetAllAsync()
        {
            var result = await _invoiceDetailRepository.GetAllAsync();
            List<InvoiceDetailResponseModel> invoiceDetailResponseModels = new List<InvoiceDetailResponseModel>();
            invoiceDetailResponseModels = result.Select(x => new InvoiceDetailResponseModel
            {
                Id = x.Id,
                InvoiceId = x.InvoiceId,
                ProductId = x.ProductId,
                OrderItemsId = x.OrderItemsId,
                Amount = x.Amount,
                UnitPrice = x.UnitPrice,
                LineTotal = x.LineTotal,
            }).ToList();

            return invoiceDetailResponseModels;
        }

        public async Task<InvoiceDetailResponseModel> GetByIdAsync(int id)
        {
            var result = await _invoiceDetailRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new InvoiceDetailResponseModel();
            }
            else
            {
                InvoiceDetailResponseModel invoiceDetailResponseModel = new InvoiceDetailResponseModel
                {
                    Id = result.Id,
                    InvoiceId = result.InvoiceId,
                    ProductId = result.ProductId,
                    OrderItemsId = result.OrderItemsId,
                    Amount = result.Amount,
                    UnitPrice = result.UnitPrice,
                    LineTotal = result.LineTotal,

                };

                return invoiceDetailResponseModel;
            }
        }

        public async Task<List<InvoiceProductDetailResponseModel>> GetProductDetailInvoiceAsync(int invoiceId)
        {
            var details = await _invoiceDetailRepository.GetByInvoiceIdAsync(invoiceId);

            return details.Select(x => new InvoiceProductDetailResponseModel
            {
                ProductName = x.Product.Name,
                Quantity = x.Amount,
                UnitPrice = x.UnitPrice,
                LineTotal = x.LineTotal,
            }).ToList();



        }
    }
}
