using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderCartItem
{
    public int? CartId { get; set; }

    public int? MenuItemId { get; set; }

    public int Quantity { get; set; }

    public virtual OrderCart? Cart { get; set; }

    public virtual MenuItem? MenuItem { get; set; }
}
