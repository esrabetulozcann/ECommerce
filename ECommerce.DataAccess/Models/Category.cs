using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ParentCategoryId { get; set; }

    public virtual Product IdNavigation { get; set; } = null!;

    public virtual ParentCategory ParentCategory { get; set; } = null!;

    public virtual ParentCategory? ParentCategoryNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
