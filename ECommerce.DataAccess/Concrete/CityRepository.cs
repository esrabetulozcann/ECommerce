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
    public class CityRepository : ICityRepository
    {
        EcommerceContext _context;

        public CityRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task AddAsync(City city)
        {
            await _context.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<List<City>> GetAllWithTown()
        {
            var city = await _context.Cities
                .Include(c => c.Towns)
                .ToListAsync();

            return city;
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _context.Cities.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<City> GetByNameAsync(string name)
        {
            return await _context.Cities.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}
