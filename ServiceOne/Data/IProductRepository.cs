using ServiceOne.Models;

namespace ServiceOne.Data
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetAllProducts();
		public Product GetProductById(int id);
		public void CreateProduct(Product product);
		public void DeleteProduct(Product product);

		public bool SaveChanges();
	}
}