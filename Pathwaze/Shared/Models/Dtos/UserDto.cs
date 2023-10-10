using System.ComponentModel.DataAnnotations;

namespace Pathwaze.Shared.Models.Dtos;

public class UserDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}
