using System.ComponentModel.DataAnnotations;

namespace ServiceOne.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public DateTime OrderDate { get; set; } = DateTime.Now;

		public ICollection<Product>? Products { get; set; } = new List<Product>();
	}
}