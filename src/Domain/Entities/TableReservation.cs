using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TableReservation
{
    public int? TableId { get; set; }

    public int? ReservationId { get; set; }

    public virtual Reservation? Reservation { get; set; }

    public virtual TableInfo? Table { get; set; }
}
