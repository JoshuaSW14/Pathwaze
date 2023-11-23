using Pathwaze.Shared.Models.Entities;

namespace Pathwaze.Shared.Models.Dtos;

public class ItemDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public decimal Cost { get; set; }
    public string? Description { get; set; }
    public bool Primary { get; set; }

    public Guid GroceryStoreId { get; set; }

    public virtual GroceryStore? GroceryStore { get; set; }
    public virtual LocationDto Location { get; set; } = new LocationDto();
    public virtual Supplier? Supplier { get; set; }
    public virtual Nutrition? Nutrition { get; set; }

    //Future
    /*
    public string BatchNumber { get; set; }
    public string StorageConditions { get; set; }
    public string AllergenInformation { get; set; }
    public virtual NutritionDto? Nutrition { get; set; }
    public DateTime ManufacturingDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Certifications { get; set; }
    public string QualityNotes { get; set; }
    public string SafetyInformation { get; set; }
     */
}
