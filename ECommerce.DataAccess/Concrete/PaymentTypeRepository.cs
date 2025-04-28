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
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        EcommerceContext _context;
        public PaymentTypeRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<PaymetnType>> GetAllAsync()
        {
            return await _context.PaymetnTypes.ToListAsync();
        }

        public async Task<PaymetnType> GetByIdAsync(int id)
        {
            return await _context.PaymetnTypes.Where(pt => pt.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PaymetnType> GetByNameAsync(string name)
        {
            return await _context.PaymetnTypes.Where(pt => pt.Name == name).FirstOrDefaultAsync();
        }
    }
}
