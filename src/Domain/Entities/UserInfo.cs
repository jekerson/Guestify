using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UserInfo
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? LastOrderAt { get; set; }

    public string Salt { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public virtual ICollection<OrderCart> OrderCarts { get; set; } = new List<OrderCart>();

    public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new List<OrderInfo>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; } = new List<UserRefreshToken>();

    public virtual ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
