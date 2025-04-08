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
    public class SizeService : ISizeService
    {
        private SizeRepository _sizeRepository;
        public SizeService(SizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task AddAsync(Size size)
        {
            await _sizeRepository.AddAsync(size);
        }

        public async Task UpdateAsync(Size size)
        {
            await _sizeRepository.UpdateAsync(size);
        }
        public async Task DeleteAsync(int id)
        {
             await _sizeRepository.DeleteAsync(id);
        }

        public async Task<List<Size>> GetAllAsync()
        {
            return await _sizeRepository.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await _sizeRepository.GetByIdAsync(id);
        }

        public async Task<Size> GetByNameAsync(string name)
        {
            return await _sizeRepository.GetByNameAsync(name);
        }

       
    }
}
