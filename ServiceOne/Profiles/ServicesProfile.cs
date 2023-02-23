using AutoMapper;
using ServiceOne.Dtos;
using ServiceOne.Models;

namespace ServiceOne.Profiles
{
	public class ServicesProfile : Profile
	{
		public ServicesProfile()
		{
			CreateMap<Product, ProductReadDto>();
			CreateMap<ProductCreateDto, Product>();
			CreateMap<Order, OrderReadDto>();
			CreateMap<OrderCreateDto, Order>()
				.ForSourceMember(dest => dest.ProductId, opts => opts.DoNotValidate());
		}
	}
}