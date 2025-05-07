using ECommerce.Core.Models.Request.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Cart
{
    public class CartRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
        public List<CartItemGetAllRequestModel> CartItems { get; set; }
    }
}
