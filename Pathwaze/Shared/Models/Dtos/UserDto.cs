using Pathwaze.Shared.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Pathwaze.Shared.Models.Dtos;

public class UserDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string? Password { get; set; }

    public string? AccountType { get; set; }

    public virtual GroceryStore? GroceryStore { get; set; }
    public virtual Supplier? Supplier { get; set; }
}
