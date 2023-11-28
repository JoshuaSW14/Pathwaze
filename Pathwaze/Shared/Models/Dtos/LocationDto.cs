namespace Pathwaze.Shared.Models.Dtos;

public class LocationDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public long FullName { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? StreetName { get; set; }
    public string? StreetNumber { get; set; }
}
