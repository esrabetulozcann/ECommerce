using ECommerce.Core.Models.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Orders
{
    public class OrderItemResponseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrdersResponseModel? Order { get; set; }
        public int ProductId { get; set; }
        public ProductResponseModel? Product { get; set; }
        public string? ProductName { get; set; } // join ile ürün adı çekilecekse
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
