using ServiceOne.Models;

namespace ServiceOne.Data
{
	/// <summary>
	/// Класс, необходимый для заполнения базы данных тестовыми данными.
	/// </summary>
	public static class PrepDb
	{
		public static void PrepData(IApplicationBuilder app)
		{
			using (var service = app.ApplicationServices.CreateScope())
			{
				SeedData(service.ServiceProvider.GetService<AppDbContext>());
			}
		}

		private static void SeedData(AppDbContext context)
		{
			if (!context.Products.Any() && !context.Orders.Any())
			{
				Console.WriteLine("--> Seeding data to Products...");

				Product firstProduct = new Product() { Id = 1, Name = "Nike Air Force 1", Description = "Shoes", Price = 139.99m };
				Product secondProduct = new Product() { Id = 2, Name = "Vans Sk8-Hi", Description = "Shoes", Price = 129.99m };
				Product thirdProduct = new Product() { Id = 3, Name = "Long Sleeve Oversized Plaid Coat", Description = "Clothing", Price = 325m };

				context.Products.AddRange(firstProduct, secondProduct, thirdProduct);

				Console.WriteLine("--> Seeding data to Orders...");

				Order firstOrder = new Order() { Name = "Alexey" };
				Order secondOrder = new Order() { Name = "Dmitry" };
				Order thirdOrder = new Order() { Name = "Natali" };

				context.Orders.AddRange(firstOrder, secondOrder, thirdOrder);

				firstOrder.Products.Add(firstProduct);
				secondOrder.Products.Add(secondProduct);
				thirdOrder.Products.Add(thirdProduct);

				context.SaveChanges();
			}
		}
	}
}