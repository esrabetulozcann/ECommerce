using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
