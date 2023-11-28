namespace Pathwaze.Client.Interfaces;

public interface IProductService
{
    public Task<ProductDto> GetProduct(Guid productId);
    public Task<List<ProductDto>> GetAllProducts();
    public Task<List<ItemDto>> SearchProducts(SearchDto searchDto);
    public Task<List<ProductDto>> GetProductsByGroceryStore(Guid groceryStoreId);
    public Task<List<ProductDto>> GetProductsBySupplier(Guid supplierId);
    public Task<bool> CreateProduct(ProductDto product);
    public Task<bool> UpdateProduct(ProductDto product);
    public Task<bool> DeleteProduct(Guid productId);
}
