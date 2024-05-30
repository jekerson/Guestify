using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class StaffNotification
{
    public Guid? StaffId { get; set; }

    public int? NotificationId { get; set; }

    public virtual Notification? Notification { get; set; }

    public virtual Staff? Staff { get; set; }
}
