using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pathwaze.Shared.Models.Entities;

namespace Pathwaze.Server.Data;

public class AppDbContext : IdentityDbContext<User>
{
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

}

