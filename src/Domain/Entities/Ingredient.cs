using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Quantity { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public virtual IngredientCategory? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
