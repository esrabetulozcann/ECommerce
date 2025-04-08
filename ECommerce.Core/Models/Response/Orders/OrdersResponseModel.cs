using ECommerce.Core.Models.Response.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Orders
{
    public class OrdersResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserResponseModel? User { get; set; } // Tekil kullanıcı bilgisi
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        // İlişkili order items'ları istersen:
        public List<OrderItemResponseModel>? OrderItems { get; set; }
        public List<UserResponseModel> Users { get; set; }
    }
}
