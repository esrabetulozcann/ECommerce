using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
