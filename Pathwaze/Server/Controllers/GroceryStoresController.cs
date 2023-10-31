namespace Pathwaze.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroceryStoresController
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public GroceryStoresController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

}

