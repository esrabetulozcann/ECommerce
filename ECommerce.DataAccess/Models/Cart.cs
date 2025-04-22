using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDelete { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual User User { get; set; } = null!;
}
