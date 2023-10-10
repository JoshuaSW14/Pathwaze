namespace Pathwaze.Shared.Models.Entities;

public class Address
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public long FullName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? StreetName { get; set; }
    public string? StreetNumber { get; set; }
    public DateTime CreationDate { get; set; }
}

