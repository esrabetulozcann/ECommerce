using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class PaymetnType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
