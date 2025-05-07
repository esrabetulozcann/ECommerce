using ECommerce.Core.Models.Request.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Cart
{
    public class CartAddRequestModel
    {
        public int UserId { get; set; }
        public List<CartItemAddRequestModel> CartItems { get; set; }
    }
}
