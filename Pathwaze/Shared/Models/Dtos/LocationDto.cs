namespace Pathwaze.Shared.Models.Dtos;

public class LocationDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
}
