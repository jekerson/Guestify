using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderCart
{
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public virtual UserInfo? User { get; set; }
}
