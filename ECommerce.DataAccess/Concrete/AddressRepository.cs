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
    public class AddressRepository : IAddressRepository
    {
        EcommerceContext _context;
        public AddressRepository(EcommerceContext context)
        {
            _context = new();
        }

        

        public async Task<List<Address>> GetAllActiveAsync()
        {
            return await _context.Addresses.Where(a => !a.IsDelete).ToListAsync();
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _context.Addresses.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Address>> GetByUserIdAsync(int userId)
        {
            return await _context.Addresses.Where(a => a.UserId == userId && !a.IsDelete).ToListAsync();
        }


        public async Task AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                address.IsDelete = true;
                _context.Addresses.Update(address);
                await _context.SaveChangesAsync();
            }
                
        }
    }
}
