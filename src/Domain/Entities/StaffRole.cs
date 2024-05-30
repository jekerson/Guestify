using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class StaffRole
{
    public int Id { get; set; }

    public Guid? StaffId { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Staff? Staff { get; set; }
}
