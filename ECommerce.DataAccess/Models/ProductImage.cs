﻿using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public bool IsDelete { get; set; }

    public virtual Product Product { get; set; } = null!;
}
