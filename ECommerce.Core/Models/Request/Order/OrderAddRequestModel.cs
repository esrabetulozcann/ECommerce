using ECommerce.Core.Models.Request.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Order
{
    public class OrderAddRequestModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public List<OrderItemAddRequestModel> OrderItems { get; set; }
    }
}
