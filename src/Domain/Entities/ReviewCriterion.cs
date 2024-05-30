using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReviewCriterion
{
    public int? UserRevoewId { get; set; }

    public int? UserReviewCriteriaId { get; set; }

    public virtual UserReviewCriterion? UserReviewCriteria { get; set; }

    public virtual UserReview? UserRevoew { get; set; }
}
