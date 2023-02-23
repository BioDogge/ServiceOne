﻿using System.ComponentModel.DataAnnotations;

namespace ServiceOne.Dtos
{
	public class ProductCreateDto
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}