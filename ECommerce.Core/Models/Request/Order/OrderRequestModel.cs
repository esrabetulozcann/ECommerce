using ECommerce.Core.Models.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Order
{
    public class OrderRequestModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public bool Status { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public UserRequestModel User { get; set; }
    }
}
