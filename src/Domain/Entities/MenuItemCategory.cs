using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class MenuItemCategory
{
    public int? ItemId { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsDefault { get; set; }

    public virtual ItemCategory? Category { get; set; }

    public virtual MenuItem? Item { get; set; }
}
