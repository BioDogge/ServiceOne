using Microsoft.AspNetCore.Mvc;
using ServiceOne.Data;
using ServiceOne.Models;

namespace ServiceOne.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class OrdersController : Controller
	{
		private readonly IOrderRepository _repository;

		public OrdersController(IOrderRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Order>> GetAllOrders()
		{
			var orders = _repository.GetAllOrders();

			return Ok(orders);
		}

		[HttpPost("products/{productId}")]
		public ActionResult AddOrder(Order order, int productId)
		{
			var product = _repository.ProductExist(productId);
			if (product != null)
				order.Products.Add(product);

			_repository.CreateOrder(order);
			_repository.SaveChanges();

			return Ok();
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteOrder(int id)
		{
			var order = _repository.GetOrderById(id);

			if (order == null) 
				return NotFound();

			_repository.DeleteOrder(order);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}