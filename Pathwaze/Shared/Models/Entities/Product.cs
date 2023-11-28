namespace Pathwaze.Shared.Models.Entities;

public class Product : BaseEntity
{
    public Guid Id { get; set; }
    public Guid? GroceryStoreId { get; set; }
    public Guid? SupplierId { get; set; }

    public virtual List<Item>? Items { get; set; }
    public virtual GroceryStore? GroceryStore { get; set; }
    public virtual Supplier? Supplier { get; set; }
}

