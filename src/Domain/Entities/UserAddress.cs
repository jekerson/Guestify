using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UserAddress
{
    public Guid? UserId { get; set; }

    public int? AddressId { get; set; }

    public bool? IsDefault { get; set; }

    public virtual Address? Address { get; set; }

    public virtual UserInfo? User { get; set; }
}
