using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderInfo
{
    public int Id { get; set; }

    public int? OrderTypeId { get; set; }

    public int? TableId { get; set; }

    public Guid? WaiterId { get; set; }

    public Guid? UserId { get; set; }

    public int? PromocodeId { get; set; }

    public int NumberOfGuest { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public string? Comment { get; set; }

    public decimal TotalSum { get; set; }

    public int? OrderStatusId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual OrderType? OrderType { get; set; }

    public virtual Promocode? Promocode { get; set; }

    public virtual TableInfo? Table { get; set; }

    public virtual UserInfo? User { get; set; }

    public virtual ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();

    public virtual Staff? Waiter { get; set; }
}
