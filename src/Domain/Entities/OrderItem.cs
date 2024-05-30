using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderItem
{
    public int Id { get; set; }

    public int? OrderInfoId { get; set; }

    public Guid? ChefId { get; set; }

    public int? MenuItemId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool? IsReady { get; set; }

    public virtual Staff? Chef { get; set; }

    public virtual MenuItem? MenuItem { get; set; }

    public virtual OrderInfo? OrderInfo { get; set; }
}
