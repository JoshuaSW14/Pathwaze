namespace Pathwaze.Shared.Models.Entities;

public class RecipeBook : BaseEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public virtual List<Recipe>? Recipes { get; set; }
}

