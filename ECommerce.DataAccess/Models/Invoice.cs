using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int AddressId { get; set; }

    public DateTime Date { get; set; }

    public string CargoFichNo { get; set; } = null!;

    public double TotalPrice { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual Order Order { get; set; } = null!;
}
