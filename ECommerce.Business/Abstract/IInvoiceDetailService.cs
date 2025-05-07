using ECommerce.Core.Models.Response.Invoice;
using ECommerce.Core.Models.Response.InvoiceDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IInvoiceDetailService
    {
        Task<List<InvoiceDetailResponseModel>> GetAllAsync();
        Task<InvoiceDetailResponseModel> GetByIdAsync(int id);
        Task<List<InvoiceProductDetailResponseModel>> GetProductDetailInvoiceAsync(int invoiceId);
    }
}
