using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.Categories;
using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Abstract;
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
        private readonly IColourRepository _colourRepository;
        public ColourService(IColourRepository colourRepository)
        {
            _colourRepository = colourRepository;
        }

        public async Task AddAsync(Colour colour)
        {
            var existing = await _colourRepository.GetByNameAsync(colour.Name);
            if (existing != null)
                throw new Exception("Bu isimde bir renk zaten mevcut");

            await _colourRepository.AddAsync(existing);
        }

        public async Task<List<ColourResponseModel>> GetAllAsync()
        {
            var result = await _colourRepository.GetAllAsync();

            List<ColourResponseModel> responseModels = new List<ColourResponseModel>();

            responseModels = result.Select(c => new ColourResponseModel
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return responseModels;
        }

        public async Task<ColourResponseModel> GetByIdAsync(int id)
        {
            var result = await _colourRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new ColourResponseModel();
            }
            else
            {
                ColourResponseModel responseModel = new ColourResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    //ProductColurId = result.ProductColours.Select(pc => pc.Id).FirstOrDefault(),
                };
                return responseModel;
            }
        }

        public async Task<ColourResponseModel> GetByNameAsync(string name)
        {
            var result = await _colourRepository.GetByNameAsync(name);
            if(result == null)
            {
                return new ColourResponseModel();
            }
            else
            {
                ColourResponseModel responseModel = new ColourResponseModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    //ProductColurId = result.ProductColours.Select(pc => pc.Id).FirstOrDefault(),
                };

                return responseModel;
            }
        }
    }
}
