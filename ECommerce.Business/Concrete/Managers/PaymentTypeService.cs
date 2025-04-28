using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        public PaymentTypeService(IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeRepository = paymentTypeRepository;
        }

        public async Task<List<BaseDTO>> GetAllAsync()
        {
            var result = await _paymentTypeRepository.GetAllAsync();
            List<BaseDTO> baseDTOs = new List<BaseDTO>();
            baseDTOs = result.Select(pt => new BaseDTO
            {
                Id = pt.Id,
                Name = pt.Name,
            }).ToList();

            return baseDTOs;
        }

        public async Task<BaseDTO> GetByIdAsync(int id)
        {
            var result = await _paymentTypeRepository.GetByIdAsync(id);
            if(result == null)
            {
                return new BaseDTO();
            }
            else
            {
                BaseDTO baseDTO = new BaseDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                };
                return baseDTO;
            }
        }

        public async Task<BaseDTO> GetByNameAsync(string name)
        {
            var result = await _paymentTypeRepository.GetByNameAsync(name);
            if(result == null)
            {
                return new BaseDTO();
            }
            else
            {
                BaseDTO baseDTO = new BaseDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                };
                return baseDTO;
            }
        }
    }
}
