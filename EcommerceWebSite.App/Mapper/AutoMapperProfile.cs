using AutoMapper;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;

namespace EcommerceWebSite.App.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateOrUpdateProductDTO, Product>().ReverseMap();
            CreateMap<GetAllProductDTO, Product>().ReverseMap();
			CreateMap<OrderDTO, Order>().ReverseMap();
			CreateMap<OrderDetailsDTO, OrderDetails>().ReverseMap();
		}
    }
}
