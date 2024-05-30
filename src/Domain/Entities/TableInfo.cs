using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TableInfo
{
    public int Id { get; set; }

    public int TableNumber { get; set; }

    public int Seats { get; set; }

    public int? TableStatusId { get; set; }

    public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new List<OrderInfo>();

    public virtual TableStatus? TableStatus { get; set; }
}
