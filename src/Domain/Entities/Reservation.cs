using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Reservation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Guests { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual UserInfo? User { get; set; }
}
