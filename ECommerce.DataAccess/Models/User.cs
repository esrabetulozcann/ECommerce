using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public string PhoneNumber1 { get; set; } = null!;

    public string PhoneNumber2 { get; set; } = null!;

    public bool IsDelete { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
