﻿using ServiceOne.Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceOne.Dtos
{
	public class ProductReadDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }
	}
}