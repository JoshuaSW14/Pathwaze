namespace Pathwaze.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public SuppliersController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

}

