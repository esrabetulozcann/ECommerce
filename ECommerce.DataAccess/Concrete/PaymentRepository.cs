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
    public class PaymentRepository : IPaymentRepository
    {
        EcommerceContext _context;
        public PaymentRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .Include(p => p.Order)
                .Include(p =>p.PaymentType)
                .ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Payment> IsOkAsync(bool isOk)
        {
            return await _context.Payments.Where(p => p.Isok == isOk).FirstOrDefaultAsync();
        }
    }
}
