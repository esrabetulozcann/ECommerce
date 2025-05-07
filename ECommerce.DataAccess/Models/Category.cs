using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Category
{
    public int Id { get; set; }

    public int? ParentCategoryId { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
