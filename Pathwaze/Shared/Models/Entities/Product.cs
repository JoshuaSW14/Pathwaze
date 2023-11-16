namespace Pathwaze.Shared.Models.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public virtual List<Item>? Items { get; set; }
    public virtual Guid? GroceryStoreId { get; set; }
    public virtual Guid? RecipeId { get; set; }
    public virtual Guid? SupplierId { get; set; }
}

