using System;
using System.Collections.Generic;

namespace HeseTazegi.Read.Context.Models;

public partial class Food
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual ICollection<FoodIngredient> FoodIngredients { get; set; } = new List<FoodIngredient>();
}
