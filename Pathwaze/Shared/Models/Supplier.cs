namespace Pathwaze.Shared.Models;

public class Supplier
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateTime LastUpdatedDate { get; set; }
	public DateTime CreationDate { get; set; }
	public bool IsDeleted { get; set; }

	public virtual Address Address { get; set; }
	public virtual List<Product> Products { get; set; }
	public virtual List<GroceryStore> GroceryStores { get; set; }
}

