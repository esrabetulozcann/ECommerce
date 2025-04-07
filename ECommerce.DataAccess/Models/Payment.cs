using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public DateTime Date { get; set; }

    public byte PaymentType { get; set; }

    public bool Isok { get; set; }

    public string ApproveCode { get; set; } = null!;

    public double PaymentTotal { get; set; }

    public virtual Order Order { get; set; } = null!;
}
