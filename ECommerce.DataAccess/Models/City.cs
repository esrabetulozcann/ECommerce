using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class City
{
    public int Id { get; set; }

    public int CountryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Town> Towns { get; set; } = new List<Town>();
}
