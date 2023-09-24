namespace Pathwaze.Shared.Models;

public class Recipe
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public long Description { get; set; }
	public DateTime LastUpdatedDate { get; set; }
	public DateTime CreationDate { get; set; }
	public bool IsDeleted { get; set; }

	public virtual Nutrition? Nutrition { get; set; }
	public virtual List<Product>? Products { get; set; }
}

