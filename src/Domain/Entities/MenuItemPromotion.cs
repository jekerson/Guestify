using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class MenuItemPromotion
{
    public int? ItemId { get; set; }

    public int? PromotionId { get; set; }

    public virtual MenuItem? Item { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
