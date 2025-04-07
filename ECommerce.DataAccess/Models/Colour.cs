using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Colour
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductColour> ProductColours { get; set; } = new List<ProductColour>();
}
