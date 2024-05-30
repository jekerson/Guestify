using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class IngredientCategory
{
    public int Id { get; set; }

    public int? ParentCateghoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<IngredientCategory> InverseParentCateghory { get; set; } = new List<IngredientCategory>();

    public virtual IngredientCategory? ParentCateghory { get; set; }
}
