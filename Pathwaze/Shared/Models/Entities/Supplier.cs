namespace Pathwaze.Shared.Models.Entities;

public class Supplier : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual List<Product>? Products { get; set; }
    public virtual List<GroceryStore>? GroceryStores { get; set; }
}

