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
    public class InvoiceRepository : IInvoiceRepository
    {
        EcommerceContext _context;
        public InvoiceRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<Invoice>> GetAllAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetByIdAsync(int id)
        {
            return await _context.Invoices.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Invoice> GetByOrderIdAsync(int orderId)
        {
            return await _context.Invoices.Where(i => i.OrderId == orderId).Include(i => i.Order).FirstOrDefaultAsync();
        }
    }
}
