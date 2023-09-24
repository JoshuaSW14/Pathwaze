namespace Pathwaze.Shared.Models;

public class RecipeBook
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public DateTime LastUpdatedDate { get; set; }
	public DateTime CreationDate { get; set; }
	public bool IsDeleted { get; set; }

	public virtual List<Recipe>? Recipes { get; set; }
}

