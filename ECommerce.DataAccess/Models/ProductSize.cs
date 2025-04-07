using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class ProductSize
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
