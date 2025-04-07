using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Size
{
    public int Id { get; set; }

    public int SizeTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

    public virtual SizeType SizeType { get; set; } = null!;
}
