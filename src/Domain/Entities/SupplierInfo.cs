using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class SupplierInfo
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string UrlAddress { get; set; } = null!;

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
