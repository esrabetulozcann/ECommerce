using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class ColourRepository : IColourRepository
    {
        private EcommerceContext _context;
        public ColourRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<List<Colour>> GetAllAsync()
        {
            return _context.Colours.ToList();
        }

        public async Task<ColourResponseModel> GetByIdAsync(int id)
        {
            var colour = _context.Colours
                .Where(c=> c.Id == id)
                .Select(c => new ColourResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList()
                .FirstOrDefault();
            return colour;
        }

        public async Task<ColourResponseModel> GetByNameAsync(string name)
        {
            var colour = _context.Colours
                .Where(c => c.Name == name)
                .Select(c => new ColourResponseModel
                {
                    Name = c.Name,
                    Id = c.Id,
                }).ToList()
                .FirstOrDefault();
            return colour;
        }
    }
}
