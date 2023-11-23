using Pathwaze.Server.Services;

namespace Pathwaze.Server.Data;

public class SeedData
{
    private IUsersRepository _usersRepository;
    private ICurrentUserService _currentUserService;

    public SeedData(IUsersRepository usersRepository, ICurrentUserService currentUserService)
    {
        _usersRepository = usersRepository;
        _currentUserService = currentUserService;
    }

    public async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
    {
        using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            context.IsSeedingOperation = true;

            _usersRepository = serviceProvider.GetService<IUsersRepository>()!;

            var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@pathwaze.com", "admin");
            await EnsureRole(serviceProvider, adminID, "Administrator");

            var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@pathwaze.com", "manager");
            await EnsureRole(serviceProvider, managerID, "Manager");

            var userID = await EnsureUser(serviceProvider, testUserPw, "user@pathwaze.com", "user");
            await EnsureRole(serviceProvider, userID, "User");

            SeedDB(context, adminID);
        }
    }
    
    private async Task<string> EnsureUser(IServiceProvider serviceProvider, string testUserPw, string UserName, string accountType)
    {
        var userManager = serviceProvider.GetService<UserManager<User>>();

        var user = await userManager.FindByNameAsync(UserName);
        if (user == null)
        {
            user = await _usersRepository.Register(new UserDto()
            {
                Email = UserName,
                Password = testUserPw,
                AccountType = accountType
            });
        }

        if (user == null)
        {
            throw new Exception("The password is probably not strong enough!");
        }
        return user.Id;
    }

    private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
    {
        var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

        if (roleManager == null)
        {
            throw new Exception("roleManager null");
        }

        IdentityResult IR;
        if (!await roleManager.RoleExistsAsync(role))
        {
            IR = await roleManager.CreateAsync(new IdentityRole(role));
        }

        var userManager = serviceProvider.GetService<UserManager<User>>();
        var user = await userManager!.FindByIdAsync(uid);
        if (user == null)
        {
            throw new Exception("The testUserPw password was probably not strong enough!");
        }

        IR = await userManager.AddToRoleAsync(user, role);

        return IR;
    }

    public static void SeedDB(AppDbContext context, string adminId)
    {
    }
}

