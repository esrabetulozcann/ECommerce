using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.CartItem
{
    public class CartItemUpdateRequestModel
    {
        public int CartItemId { get; set; } // Hangi item güncellenecek
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsDelete { get; set; }
    }
}
