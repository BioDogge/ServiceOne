using Microsoft.AspNetCore.Mvc;
using ServiceOne.Data;
using ServiceOne.Models;

namespace ServiceOne.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductsController : Controller
	{
		private readonly IProductRepository _repository;

		public ProductsController(IProductRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Product>> GetAllProducts()
		{
			var products = _repository.GetAllProducts();

			return Ok(products);
		}

		[HttpPost]
		public ActionResult CreateProduct(Product product)
		{
			_repository.CreateProduct(product);
			_repository.SaveChanges();

			return Ok(product);
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var product = _repository.GetProductById(id);

			if (product == null)
				return NotFound();

			_repository.DeleteProduct(product);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}