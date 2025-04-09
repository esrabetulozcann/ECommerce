using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class ParentCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
