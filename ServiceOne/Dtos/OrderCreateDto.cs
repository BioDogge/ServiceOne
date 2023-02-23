using ServiceOne.Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceOne.Dtos
{
	public class OrderCreateDto
	{
		[Required]
		public string Name { get; set; }

		public ICollection<int>? ProductId { get; set; } = new List<int>();
	}
}