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
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        EcommerceContext _context;
        public InvoiceDetailRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<InvoiceDetail>> GetAllAsync()
        {
            return await _context.InvoiceDetails.ToListAsync();
        }

        public async Task<InvoiceDetail> GetByIdAsync(int id)
        {
            return await _context.InvoiceDetails.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<InvoiceDetail>> GetByInvoiceIdAsync(int invoiceId)
        {
            return await _context.InvoiceDetails
                .Where(i => i.InvoiceId == invoiceId)
                .Include(i => i.Product)
                .ToListAsync();
        }
    }
}
