namespace Pathwaze.Shared.Models.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? DisplayId { get; set; }
    public IList<ItemDto> Items { get; set; } = new List<ItemDto>();
}