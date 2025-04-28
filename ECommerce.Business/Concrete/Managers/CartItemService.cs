using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.CartItem;
using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<List<CartItemRequestModel>> GetAllAsync()
        {
            var result = await _cartItemRepository.GetAllAsync();
            List<CartItemRequestModel> cartItemRequestModels = new List<CartItemRequestModel>();
            cartItemRequestModels = result.Select(x => new CartItemRequestModel
            {
                Id = x.Id,
                CartId = x.CartId,
                Price = x.Price,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }).ToList();
            return cartItemRequestModels;
        }

        public async Task<CartItemRequestModel> GetByCartIdAsync(int cartId)
        {
            var result = await _cartItemRepository.GetByCartIdAsync(cartId);
            if(result == null)
            {
                return new CartItemRequestModel();
            }
            else
            {
                CartItemRequestModel cartItemRequestModel = new CartItemRequestModel
                {
                    Id = result.Id,
                    CartId = result.CartId,
                    Price = result.Price,
                    ProductId = result.ProductId,
                    Quantity = result.Quantity,
                };
                return cartItemRequestModel;
            }
        }

        public async Task<CartItemRequestModel> GetByIdAsync(int id)
        {
            var result = await _cartItemRepository.GetByIdAsync(id);
            if( result == null)
            {
                return new CartItemRequestModel();
            }
            else
            {
                CartItemRequestModel cartItemRequestModel = new CartItemRequestModel
                {
                    Id = result.Id,
                    CartId = result.CartId,
                    Price = result.Price,
                    ProductId = result.ProductId,
                    Quantity = result.Quantity,
                };
                return cartItemRequestModel;
            }
        }
    }
}
