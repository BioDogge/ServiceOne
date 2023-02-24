using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceOne.Data;
using ServiceOne.Dtos;
using ServiceOne.Models;

namespace ServiceOne.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : Controller
	{
		private readonly IOrderRepository _repository;
		private readonly IMapper _mapper;

		public OrdersController(IOrderRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<OrderReadDto>> GetAllOrders()
		{
			var orders = _repository.GetAllOrders();

			return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orders));
		}

		[HttpPost]
		public ActionResult<OrderReadDto> AddOrder(OrderCreateDto orderCreateDto)
		{
			var productsExist = _repository.ProductExist(orderCreateDto.ProductId);
			var orderModel = _mapper.Map<Order>(orderCreateDto);

			_repository.CreateOrder(orderModel, productsExist);
			_repository.SaveChanges();

			var orderReadDto = _mapper.Map<OrderReadDto>(orderModel);
			return Ok(orderReadDto);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteOrder(int id)
		{
			var order = _repository.GetOrderById(id);

			if (order == null) 
				return NotFound();

			_repository.DeleteOrder(order);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}