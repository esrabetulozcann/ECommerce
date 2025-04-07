using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class InvoiceDetail
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int OrderItemsId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Amount { get; set; }

    public decimal LineTotal { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual OrderItem OrderItems { get; set; } = null!;
}
