namespace Pathwaze.Shared.Models.Dtos;

public class ProductDto
{
	public Guid Id { get; set; }
    public string? DisplayId { get; set; }
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? AutoComplete { get; set; }
}

