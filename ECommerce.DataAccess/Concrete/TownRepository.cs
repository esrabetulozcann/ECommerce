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
    public class TownRepository : ITownRepository
    {
        EcommerceContext _context;
        public TownRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<Town>> GetAllAsync()
        {
            return await _context.Towns.ToListAsync();
        }

       

        public async Task<Town> GetByIdAsync(int id)
        {
            return await _context.Towns.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Town> GetByNameAsync(string name)
        {
            return await _context.Towns.Where(t => t.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Town>> GetAllWithDistrict()
        {
            var town = await _context.Towns
                .Include(t => t.Districts) 
                .ToListAsync();

            return town;
        }

        public async Task AddAsync(Town town)
        {
            await _context.Towns .AddAsync(town);
            await _context.SaveChangesAsync();
        }
    }
}
