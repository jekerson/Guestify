using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UserReviewCriterion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsPositive { get; set; }
}
