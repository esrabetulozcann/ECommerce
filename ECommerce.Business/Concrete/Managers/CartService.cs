using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Request.Cart;
using ECommerce.Core.Models.Request.CartItem;
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
        private readonly ICartItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;
        public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _itemRepository = cartItemRepository;
            _productRepository = productRepository;
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
                CartItems = x.CartItems.Select(ci => new CartItemGetAllRequestModel
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = ci.Price * ci.Quantity,
                }).ToList(),
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


        public async Task AddAsync(CartAddRequestModel cart)
        {
            var newCart = new Cart
            {
                UserId = cart.UserId,
                CreatedAt = DateTime.UtcNow,
                IsDelete = false,
            };

            await _cartRepository.AddAsync(newCart);
            var cartId = newCart.Id;

            foreach (var item in cart.CartItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new Exception("Ürün bulunamadı");

                var cartItem = new CartItem
                {
                     CartId = cartId,
                     ProductId = item.ProductId,
                     Quantity = item.Quantity,
                     Price = product.Price,
                };

                await _itemRepository.Add(cartItem);
            }

        }

       

        public async Task UpdateAsync(CartItemUpdateRequestModel model)
        {
            var cartItem = await _itemRepository.GetByIdAsync(model.CartItemId);
            if (cartItem == null)
                throw new Exception("Sepet bulunamadı");

            //Yeni ürün bilgilerini sistemden çekiyorum.
            var product = await _productRepository.GetByIdAsync(model.ProductId);
            if (product == null)
                throw new Exception("Ürün bulunamadı");


            //Güncellenecek alanlar:
            cartItem.ProductId = model.ProductId;
            cartItem.Quantity = model.Quantity;

            //Fiyat sistemden geliyor
            cartItem.Price = product.Price;
             
            await _itemRepository.UpdateAsync(cartItem);
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
