using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class SizeTypeService : ISizeTypeService
    {
        private SizeTypeRepository _sizeTypeRepository;
        public SizeTypeService(SizeTypeRepository sizeTypeRepository)
        {
             _sizeTypeRepository = sizeTypeRepository;
        }

        

        public async Task<List<Size>> GetAllAsync()
        {
            await _sizeTypeRepository.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await _sizeTypeRepository.GetByIdAsync(id);
        }

        public async Task<Size> GetByNameAsync(string name)
        {
            return await _sizeTypeRepository.GetByNameAsync(name);
        }

        public async Task AddAsync(Size size)
        {
            await _sizeTypeRepository.AddAsync(size);
           
        }
        public async Task UpdateAsync(Size size)
        {
            await _sizeTypeRepository.UpdateAsync(size);
        }
        public async Task DeleteAsync(int id)
        {
            await _sizeTypeRepository.DeleteAsync(id);
        }
    }
}
