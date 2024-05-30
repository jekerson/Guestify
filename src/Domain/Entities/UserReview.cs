using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UserReview
{
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public int? OrderId { get; set; }

    public int RatingValue { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual OrderInfo? Order { get; set; }

    public virtual UserInfo? User { get; set; }
}
