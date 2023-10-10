namespace Pathwaze.Shared.Models.Entities;

public class Item
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Nutrition? Nutrition { get; set; }
    public virtual List<Address>? Addresses { get; set; }
}

