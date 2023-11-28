namespace Pathwaze.Shared.Models.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public Guid? GroceryStoreId { get; set; }
    public Guid? SupplierId { get; set; }
    public IList<ItemDto> Items { get; set; } = new List<ItemDto>();
}