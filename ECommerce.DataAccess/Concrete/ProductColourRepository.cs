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
    public class ProductColourRepository : IProductColourRepository
    {
        private EcommerceContext _context;
        public ProductColourRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<List<ProductColour>> GetAllAsync()
        {
            return  _context.ProductColours.ToList(); // Tüm ürün renklerini getirdim.
        }

        public async Task<ProductColourResponseModel> GetByColourIdAsync(int id)
        {
            var productColour = _context.ProductColours
                .Where(x => x.Id == id)
                .Select(x => new ProductColourResponseModel
                {
                    ProductId = x.Id,
                    ColourId = x.ColourId,
                }).ToList()
                .FirstOrDefault();
            return productColour;
        }

        public async Task<ProductColourResponseModel> GetByIdAsync(int id)
        {
            var productColour = _context.ProductColours
                .Where(c => c.Id == id)
                .Select(c => new ProductColourResponseModel
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    ColourId = c.ColourId,
                }).ToList()
                .FirstOrDefault();
            return productColour;
        }

        public async Task<ProductColourResponseModel> GetByProductIdAsync(int id)
        {
            var productColour = _context.ProductColours
                .Where(c => c.Id == id)
                .Select(c => new ProductColourResponseModel
                {
                    ColourId = c.Id,
                    ProductId = c.ProductId,

                }).ToList()
                .FirstOrDefault();

            return productColour;
        }
    }
}
