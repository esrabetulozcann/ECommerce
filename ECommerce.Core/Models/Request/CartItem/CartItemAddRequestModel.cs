using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.CartItem
{
    public class CartItemAddRequestModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
