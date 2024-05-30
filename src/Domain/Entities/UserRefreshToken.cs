using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UserRefreshToken
{
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Token { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual UserInfo? User { get; set; }
}
