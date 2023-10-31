using Microsoft.EntityFrameworkCore;

namespace Pathwaze.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public ProductsController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
    {
        if(productDto is not null)
        {
            Product product = new Product()
            {
                Name = productDto.Name
            };
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return new OkObjectResult(result);
        }
        return new BadRequestResult();
    }
}

