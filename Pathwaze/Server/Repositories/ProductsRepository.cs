using Radzen;

namespace Pathwaze.Server.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly AppDbContext _context;

    public ProductsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> GetProduct(Guid productId)
    {
        try
        {
            if(productId != Guid.Empty)
            {
                var product = await _context.Products.FindAsync(productId);
                if (product != null)
                    return product.Adapt<ProductDto>();
            }
        }catch (Exception ex)
        {
            Console.WriteLine("Error Occurred in the Products Repository: " + ex.Message);
        }
        return null!;
    }

    public async Task<List<ProductDto>> GetAllProducts()
    {
        try
        {
            var products = await _context.Products.ToArrayAsync();
            if (products != null)
                return products.Adapt<List<ProductDto>>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occurred in the Products Repository: " + ex.Message);
        }
        return null!;
    }

    public async Task<List<ItemDto>> SearchProducts(SearchDto searchDto)
    {
        try
        {
            var products = await _context.Items.Where(item => item.Primary == true).ToArrayAsync();
            if (products != null)
                return products.Adapt<List<ItemDto>>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occurred in the Products Repository: " + ex.Message);
        }
        return null!;
    }

    public async Task<List<ProductDto>> GetProductsByGroceryStore(Guid groceryStoreId)
    {
        try
        {
            if (groceryStoreId != Guid.Empty)
            {
                var product = await _context.Products.Where(p => p.GroceryStore.Id == groceryStoreId).ToArrayAsync();
                if (product != null)
                    return product.Adapt<List<ProductDto>>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occurred in the Products Repository: " + ex.Message);
        }
        return null!;
    }

    public async Task<List<ProductDto>> GetProductsBySupplier(Guid supplierId)
    {
        try
        {
            if (supplierId != Guid.Empty)
            {
                var product = await _context.Products.Where(p => p.Supplier.Id == supplierId).ToArrayAsync();
                if (product != null)
                    return product.Adapt<List<ProductDto>>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occurred in the Products Repository: " + ex.Message);
        }
        return null!;
    }

    public async Task<bool> CreateProduct(ProductDto productDto)
    {
        try
        {
            if (productDto != null)
            {
                Product product = productDto.Adapt<Product>();
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
        }catch(Exception ex)
        {
            Console.WriteLine("Error Occurred in the Products Repository: " + ex.Message);
        }
        return false;
    }

    public async Task<bool> UpdateProduct(ProductDto productDto)
    {
        try
        {
            if (productDto != null)
            {
                Product product = productDto.Adapt<Product>();
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occurred in the Products Repository: " + ex.Message);
        }
        return false;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        try
        {
            if(productId != Guid.Empty)
            {
                Product product = await _context.Products.Where(p => p.Id == productId).FirstAsync();
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occurred in the Products Repository: " + ex.Message);
        }
        return false;
    }
}
