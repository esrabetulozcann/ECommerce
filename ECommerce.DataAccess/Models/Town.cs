using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Town
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
