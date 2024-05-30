using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Supplier
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public int? ContactInfoId { get; set; }

    public virtual SupplierInfo? ContactInfo { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
