using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class ColourService : IColourService
    {
        private ColourRepository _colourRepository;
        public ColourService(ColourRepository colourRepository)
        {
            _colourRepository = colourRepository;
        }

        public async Task<List<Colour>> GetAllAsync()
        {
            return await _colourRepository.GetAllAsync();
        }

        public async Task<ColourResponseModel> GetByIdAsync(int id)
        {
            return await _colourRepository.GetByIdAsync(id);
        }

        public async Task<ColourResponseModel> GetByNameAsync(string name)
        {
            return await _colourRepository.GetByNameAsync(name);
        }
    }
}
