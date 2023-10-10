using Microsoft.AspNetCore.Identity;
namespace Pathwaze.Shared.Models.Entities;

public class User : IdentityUser
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PasswordHash { get; set; }
    public string? AccountType { get; set; }
    public DateTime LastLoginDate { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Address? Address { get; set; }
    public virtual Preferences? Preferences { get; set; }
    public virtual RecipeBook? RecipeBook { get; set; }
}

