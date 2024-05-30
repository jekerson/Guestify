using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Staff
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Lastname { get; set; }

    public string Sex { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfEmployment { get; set; }

    public string? FormAtEmployment { get; set; }

    public string? Status { get; set; }

    public int? AddressId { get; set; }

    public string? Salt { get; set; }

    public string HashedPassword { get; set; } = null!;

    public virtual Address? Address { get; set; }

    public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new List<OrderInfo>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<StaffRefreshToken> StaffRefreshTokens { get; set; } = new List<StaffRefreshToken>();

    public virtual ICollection<StaffRole> StaffRoles { get; set; } = new List<StaffRole>();
}
