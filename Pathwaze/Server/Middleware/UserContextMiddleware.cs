namespace Pathwaze.Server.Middleware;

public class UserContextMiddleware
{
    private readonly RequestDelegate _next;

    public UserContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserContext userContext)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            userContext.CurrentUserId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        await _next(context);
    }
}

