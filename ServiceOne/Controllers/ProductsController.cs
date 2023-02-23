using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceOne.Data;
using ServiceOne.Dtos;
using ServiceOne.Models;

namespace ServiceOne.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : Controller
	{
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;

		public ProductsController(IProductRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
		{
			var products = _repository.GetAllProducts();

			return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
		}

		[HttpPost]
		public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto productCreateDto)
		{
			var productModel = _mapper.Map<Product>(productCreateDto);

			_repository.CreateProduct(productModel);
			_repository.SaveChanges();

			var productReadDto = _mapper.Map<ProductReadDto>(productModel);
			return Ok(productReadDto);
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var product = _repository.GetProductById(id);

			if (product == null)
				return NotFound();

			_repository.DeleteProduct(product);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}