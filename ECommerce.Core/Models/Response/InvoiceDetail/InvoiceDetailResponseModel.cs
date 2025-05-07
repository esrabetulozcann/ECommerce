using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.InvoiceDetail
{
    public class InvoiceDetailResponseModel
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int OrderItemsId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal LineTotal { get; set; }

    }
}
