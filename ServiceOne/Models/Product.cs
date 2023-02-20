using System.ComponentModel.DataAnnotations;

namespace ServiceOne.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public decimal Price { get; set; }

		public ICollection<Order>? Orders { get; set; } = new List<Order>();
	}
}