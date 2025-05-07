using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Invoice
{
    public class InvoiceResponseModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int AddressId { get; set; }

        public DateTime Date { get; set; }

        public string CargoFichNo { get; set; } = null!;

        public double TotalPrice { get; set; }
    }
}
