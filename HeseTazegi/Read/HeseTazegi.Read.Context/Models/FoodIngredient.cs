using System;
using System.Collections.Generic;

namespace HeseTazegi.Read.Context.Models;

public partial class FoodIngredient
{
    public Guid FoodId { get; set; }

    public int Id { get; set; }

    public Guid IngredientId { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual Ingredient Ingredient { get; set; } = null!;
}
