namespace Pathwaze.Shared.Models.Entities;

public class Item : BaseEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public decimal Cost { get; set; }
    public string? Description { get; set; }
    public bool Primary { get; set; }

    public Guid GroceryStoreId { get; set; }

    public virtual GroceryStore? GroceryStore { get; set; }
    public virtual Nutrition? Nutrition { get; set; }
    public virtual Location? Location { get; set; }
}

