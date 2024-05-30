using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Notification
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool? IsRead { get; set; }
}
