using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IInvoiceDetailRepository
    {
        Task<List<InvoiceDetail>> GetAllAsync();
        Task<InvoiceDetail> GetByIdAsync(int id);
        Task<List<InvoiceDetail>> GetByInvoiceIdAsync(int invoiceId);



    }
}
