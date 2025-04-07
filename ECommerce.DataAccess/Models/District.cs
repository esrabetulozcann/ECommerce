using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class District
{
    public int Id { get; set; }

    public int TownId { get; set; }

    public string District1 { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Town Town { get; set; } = null!;
}
