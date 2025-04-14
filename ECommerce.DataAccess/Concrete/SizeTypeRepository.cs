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
    public class SizeTypeRepository : ISizeTypeRepository
    {
         EcommerceContext _context;

        public SizeTypeRepository(EcommerceContext context)
        {
            _context = new();
        }

        

        public async Task<List<SizeType>> GetAllAsync()
        {
            return await _context.SizeTypes.ToListAsync();
        }

        public async Task<SizeType> GetByIdAsync(int id)
        {
            return await _context.SizeTypes.Where(st => st.Id == id).FirstOrDefaultAsync();
        }

        public async Task<SizeType> GetByNameAsync(string name)
        {
            return await _context.SizeTypes.Where(st => st.Name == name).FirstOrDefaultAsync();
        }
      
       

        
    }
}
