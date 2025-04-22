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
    public class CountryRepository : ICountryRepository
    {
        EcommerceContext _context;

        public CountryRepository(EcommerceContext context)
        {
            _context = new();
        }


        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Country> GetByNameAsync(string name)
        {
            return await _context.Countries.Where(c => c.Name == name).FirstOrDefaultAsync();
        }


        public async Task AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAllWithCities()
        {
            var country = await _context.Countries.
                Include(c => c.Cities)
                .ToListAsync();

            return country;
        }
    }
}
