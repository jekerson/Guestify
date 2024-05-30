using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ItemIngredient
{
    public int? ItemId { get; set; }

    public int? IngredientId { get; set; }

    public decimal Quantity { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual MenuItem? Item { get; set; }
}
