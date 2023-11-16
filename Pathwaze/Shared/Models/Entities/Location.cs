namespace Pathwaze.Shared.Models.Entities;

public class Location
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
}
