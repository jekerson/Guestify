using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UserPromocode
{
    public Guid? UserId { get; set; }

    public int? PromocodeId { get; set; }

    public virtual Promocode? Promocode { get; set; }

    public virtual UserInfo? User { get; set; }
}
