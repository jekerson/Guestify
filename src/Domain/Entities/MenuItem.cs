using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class MenuItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImagePath { get; set; }

    public decimal Price { get; set; }

    public bool? IsVegan { get; set; }

    public bool? IsAlcohol { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
