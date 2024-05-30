using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class StaffRefreshToken
{
    public int Id { get; set; }

    public Guid? StaffId { get; set; }

    public string? Token { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Staff? Staff { get; set; }
}
