using Microsoft.EntityFrameworkCore;
using ServiceOne.Models;

namespace ServiceOne.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> opts)
			: base(opts) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}