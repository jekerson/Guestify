using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new List<OrderInfo>();
}
