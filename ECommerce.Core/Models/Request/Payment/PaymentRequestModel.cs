using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Payment
{
    public class PaymentRequestModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int PaymentTypeId { get; set; }
        public bool Isok { get; set; }
        public string ApproveCode { get; set; }
        public double PaymentTotal { get; set; }   
    }
}
