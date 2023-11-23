namespace Pathwaze.Server.Services;

public interface ICurrentUserService
{
	Task<string> GetCurrentUserId();
}

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, AppDbContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }

    public async Task<string> GetCurrentUserId()
    {
        var email = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        if (string.IsNullOrEmpty(email))
        {
            return null!;
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
            return user?.Id!;
        else
            return null!;
    }
}

