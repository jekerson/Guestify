using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Promocode
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Discount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal? MaxDiscount { get; set; }

    public bool? IsUsed { get; set; }

    public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new List<OrderInfo>();
}
