namespace Pathwaze.Shared.Models;

public class Product
{
	public Guid Id { get; set; }
	public string? Name { get; set; }

	public virtual List<Item>? Items { get; set; }
}

