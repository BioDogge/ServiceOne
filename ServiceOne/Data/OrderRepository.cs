using Microsoft.EntityFrameworkCore;
using ServiceOne.Models;

namespace ServiceOne.Data
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _context;

		public OrderRepository(AppDbContext context)
		{
			_context = context;
		}

		public void CreateOrder(Order order)
		{
			_context.Orders.Add(order);
		}

		public void DeleteOrder(Order order)
		{
			if (order != null)
				_context.Orders.Remove(order);
		}

		public IEnumerable<Order> GetAllOrders()
		{
			return _context.Orders.Include(o => o.Products).ToList();
		}

		public Order GetOrderById(int id)
		{
			return _context.Orders.FirstOrDefault(o => o.Id == id);
		}

		public Product IsProductExist(int productId)
		{
			return _context.Products.FirstOrDefault(p => p.Id == productId);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}
	}
}