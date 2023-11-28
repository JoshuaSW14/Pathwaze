namespace Pathwaze.Shared.Models.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? AccountType { get; set; }
    public DateTime LastLoginDate { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public bool Deleted { get; set; }

    public virtual Preferences? Preferences { get; set; }
    public virtual RecipeBook? RecipeBook { get; set; }
    public virtual GroceryStore? GroceryStore { get; set; }
    public virtual Supplier? Supplier { get; set; }
}

