namespace Pathwaze.Shared.Models.Entities;

public class GroceryStore : BaseEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public virtual List<Product>? Products { get; set; }
    public virtual List<Location>? Locations { get; set; }
    public virtual List<Supplier>? Suppliers { get; set; }
}

