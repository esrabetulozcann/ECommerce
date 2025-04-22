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
    public class DistrictRepository : IDistrictRepository
    {
        EcommerceContext _context;
        public DistrictRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task AddAsync(District district)
        {
            await _context.Districts.AddAsync(district);
            await _context.SaveChangesAsync();
        }

        public async Task<List<District>> GetAllAsync()
        {
            return await _context.Districts.ToListAsync();
        }

        public async Task<District> GetByIdAsync(int id)
        {
            return await _context.Districts.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<District> GetByNameAsync(string name)
        {
            return await _context.Districts.Where(d => d.Name == name).FirstOrDefaultAsync();
        }
    }
}
