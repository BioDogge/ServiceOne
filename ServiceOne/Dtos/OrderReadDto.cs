using ServiceOne.Models;

namespace ServiceOne.Dtos
{
	public class OrderReadDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime OrderDate { get; set; }

		public ICollection<ProductReadDto>? Products { get; set; }
	}
}