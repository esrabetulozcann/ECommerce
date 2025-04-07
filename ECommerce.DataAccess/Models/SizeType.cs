using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class SizeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();
}
