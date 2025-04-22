using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class Address
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CountryId { get; set; }

    public int CityId { get; set; }

    public int TownId { get; set; }

    public int DistrictId { get; set; }

    public string PostalCode { get; set; } = null!;

    public string AddressText { get; set; } = null!;

    public bool IsDelete { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual District District { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Town Town { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
