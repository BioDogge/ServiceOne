using ServiceOne.Models;

namespace ServiceOne.Data
{
	public interface IOrderRepository
	{
		public IEnumerable<Order> GetAllOrders();

		public void CreateOrder(Order order);
		public Order GetOrderById(int id);
		public void DeleteOrder(Order order);

		public IEnumerable<Product> ProductExist(IEnumerable<int> productId);

		public bool SaveChanges();
	}
}