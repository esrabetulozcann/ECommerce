using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Cart;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        
        public async Task<List<CartRequestModel>> GetAllAsync()
        {
            var result = await _cartRepository.GetAllAsync();
            List<CartRequestModel> cartRequestModels = new List<CartRequestModel>();
            cartRequestModels = result.Select(x => new CartRequestModel
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                IsDelete = x.IsDelete,
                UserId = x.UserId,
            }).ToList();
            return cartRequestModels;
        }

        public async Task<CartRequestModel> GetByIdAsync(int id)
        {
            var resul = await _cartRepository.GetByIdAsync(id);
            if(resul == null)
            {
                return new CartRequestModel();
            }
            else
            {
                CartRequestModel cartRequestModel = new CartRequestModel
                {
                    Id = resul.Id,
                    CreatedAt = resul.CreatedAt,
                    IsDelete = resul.IsDelete,
                    UserId = resul.UserId,
                };
                return cartRequestModel;
            }
        }

        public async Task<List<CartRequestModel>> GetByUserId(int userId)
        {
            var result = await _cartRepository.GetByUserIdAsync(userId);
            List<CartRequestModel> cartRequestModels = new List<CartRequestModel>();

            cartRequestModels = result.Select(c => new CartRequestModel
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                IsDelete = c.IsDelete,
                UserId = c.UserId,
            }).ToList();

            return cartRequestModels;
        }


        public Task AddAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

       

        public Task UpdateAsync(Cart cart)
        {
            throw new NotImplementedException();
        }


        public async Task DeleteAsync(int id)
        {
            var existing = await _cartRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Silinecek sepet bulunamadı");

            await _cartRepository.DeleteAsync(id);
        }
    }
}
