using ECommerce.Core.Models.Response.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IInvoiceService
    {
        Task<List<InvoiceResponseModel>> GetAllAsync();
        Task<InvoiceResponseModel> GetByIdAsync(int id);
        Task<InvoiceOrderDetailResponseModel> GetByOrderIdAsync(int orderId);
    }
}
