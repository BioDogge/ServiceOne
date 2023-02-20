using ServiceOne.Models;

namespace ServiceOne.Data
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;

		public ProductRepository(AppDbContext context)
		{
			_context = context;
		}

		public void DeleteProduct(Product product)
		{
			if (product != null)
				_context.Products.Remove(product);
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _context.Products.ToList();
		}

		public Product GetProductById(int id)
		{
			return _context.Products.FirstOrDefault(p => p.Id == id);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}
	}
}