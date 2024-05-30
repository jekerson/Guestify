using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UserNotificaiton
{
    public Guid? UserId { get; set; }

    public int? NotificationId { get; set; }

    public virtual Notification? Notification { get; set; }

    public virtual UserInfo? User { get; set; }
}
