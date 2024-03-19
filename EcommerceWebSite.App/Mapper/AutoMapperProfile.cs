using AutoMapper;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using EcommerceWebSite.Domain.DTOs.CartItem;
namespace EcommerceWebSite.App.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateOrUpdateProductDTO, Product>().ReverseMap();
            CreateMap<GetAllProductDTO, Product>().ReverseMap();


            CreateMap<CreateOrUpdateCategoryDTO, Category>().ReverseMap();
            CreateMap<GetAllCategoryDTO, Category>().ReverseMap();

            CreateMap<CreateOrUpdateCartItemDto, CartItem>().ReverseMap();
            CreateMap<GetCartItemDto, CartItem>().ReverseMap();


            CreateMap<CreateOrUpdateSubCategoryDTO, SubCategory>().ReverseMap();
            CreateMap<GetAllSubCategoryDTO, SubCategory>().ReverseMap();

          
        }
    }
    
}
