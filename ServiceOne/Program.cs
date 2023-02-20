using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ServiceOne.Data;

namespace ServiceOne
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<AppDbContext>(opts =>
				opts.UseInMemoryDatabase("ServiceInMemoryDB"));

			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();

			builder.Services.AddControllers().AddNewtonsoftJson(s =>
			{
				s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			});

			builder.Services.AddAuthorization();

			var app = builder.Build();

			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
				endpoints.MapControllers());

			//Заполнение тестовыми данными.
			PrepDb.PrepData(app); 

			app.Run();
		}
	}
}