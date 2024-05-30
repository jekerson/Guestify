using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderLine
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public bool? IsShow { get; set; }

    public virtual OrderInfo? Order { get; set; }
}
