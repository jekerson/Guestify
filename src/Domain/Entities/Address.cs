using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Address
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string? BuildingNumber { get; set; }

    public string? ApartmentNumber { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<SupplierInfo> SupplierInfos { get; set; } = new List<SupplierInfo>();
}
