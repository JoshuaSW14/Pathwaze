namespace Pathwaze.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase 
{
    private readonly IProductsRepository _productsRepository;

    public ProductsController(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    #region GetRequests
    [HttpGet("GetProduct/{productId}")]
    public async Task<IActionResult> GetProduct(Guid productId)
    {
        ProductDto product = await _productsRepository.GetProduct(productId);
        if(product != null)
            return Ok(product);
        return BadRequest();
    }

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        List<ProductDto> products = await _productsRepository.GetAllProducts();
        if (products != null)
            return Ok(products);
        return BadRequest();
    }

    [HttpGet("GetProductsByGroceryStore/{groceryStoreId}")]
    public async Task<IActionResult> GetProductsByGroceryStore(Guid groceryStoreId)
    {
        List<ProductDto> products = await _productsRepository.GetProductsByGroceryStore(groceryStoreId);
        if (products != null)
            return Ok(products);
        return BadRequest();
    }

    [HttpGet("GetProductsBySupplier/{supplierId}")]
    public async Task<IActionResult> GetProductsBySupplier(Guid supplierId)
    {
        List<ProductDto> products = await _productsRepository.GetProductsBySupplier(supplierId);
        if (products != null)
            return Ok(products);
        return BadRequest();
    }
    #endregion

    #region PostRequests
    [HttpPost("CreateProduct")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        bool response = await _productsRepository.CreateProduct(productDto);
        return Ok(response);
    }
    #endregion

    #region PutRequests
    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
    {
        bool response = await _productsRepository.UpdateProduct(productDto);
        return Ok(response);
    }
    #endregion

    #region DeleteRequests
    [HttpDelete("DeleteProduct/{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        bool response = await _productsRepository.DeleteProduct(productId);
        return Ok(response);
    }
    #endregion

}

