﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<StaffRole> StaffRoles { get; set; } = new List<StaffRole>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
