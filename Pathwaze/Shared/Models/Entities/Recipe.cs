namespace Pathwaze.Shared.Models.Entities;

public class Recipe : BaseEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public long Description { get; set; }

    public virtual Nutrition? Nutrition { get; set; }
    public virtual List<Product>? Products { get; set; }
}

