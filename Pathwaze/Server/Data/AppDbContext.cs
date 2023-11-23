using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Pathwaze.Server.Data;

public class AppDbContext : IdentityDbContext<User>
{
    private readonly UserContext _userContext;
    public bool IsSeedingOperation { get; set; } = false;

    public AppDbContext(DbContextOptions<AppDbContext> options, UserContext userContext) : base(options)
    {
        _userContext = userContext;
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    //public DbSet<User> Users { get; set; }
    public DbSet<Preferences> Preferences { get; set; }
	public DbSet<Item> Items { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Nutrition> Nutritions { get; set; }
	public DbSet<GroceryStore> GroceryStores { get; set; }
	public DbSet<Supplier> Suppliers { get; set; }
	public DbSet<Recipe> Recipes { get; set; }
	public DbSet<RecipeBook> RecipeBooks { get; set; }
	public DbSet<Address> Addresses { get; set; }
	public DbSet<Location> Locations { get; set; }

    public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess)
    {
        if (!IsSeedingOperation)
        {
            var addedEntities = ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added);

            foreach (var entityEntry in addedEntities)
            {
                var entity = entityEntry.Entity;
                entity.CreationDate = DateTime.UtcNow;
                entity.CreationUserId = Guid.Parse(_userContext.CurrentUserId);
            }
        }
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess);
    }
}

