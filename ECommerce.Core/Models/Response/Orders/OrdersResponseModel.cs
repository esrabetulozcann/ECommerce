using ECommerce.Core.Models.Request.User;
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
        public int AddressId { get; set; }
        public bool Status { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public UserRequestModel Users { get; set; }
    }
}
