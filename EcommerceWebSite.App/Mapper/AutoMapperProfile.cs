using AutoMapper;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using EcommerceWebSite.Domain.DTOs.CartItem;
using EcommerceWebSite.Domain.DTOs.Products;
using EcommerceWebSite.Domain.DTOs.Comment;
using System.Threading.Tasks;
namespace EcommerceWebSite.App.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateOrUpdateProductDTO, Product>().ReverseMap();
            CreateMap<GetAllProductDTO, Product>().ForMember(dest => dest.imgURL, opt => opt.MapFrom(src => src.imgURL)).ReverseMap();
            CreateMap<CreateOrUpdateCategoryDTO, Category>().ReverseMap();
            CreateMap<GetAllCategoryDTO, Category>().ReverseMap();
            CreateMap<CreateOrUpdateSubCategoryDTO, SubCategory>().ReverseMap();
            CreateMap<GetAllSubCategoryDTO, SubCategory>().ReverseMap();
            CreateMap<CreateOrUpdateCartItemDto,CartItem>().ReverseMap();
            CreateMap<GetCartItemDto,CartItem>().ReverseMap();
            CreateMap<CommentDto,Comment> ().ReverseMap();
            CreateMap<OrderDetailsDTO,OrderDetails>().ReverseMap();
            CreateMap<OrderDTO,Order>().ReverseMap();
            CreateMap<GetOrderDto,Order>().ReverseMap();
            CreateMap<Task<CartItem>, CreateOrUpdateCartItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Result.ProductId))
                .ForMember(dest => dest.CustId, opt => opt.MapFrom(src => src.Result.CustId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Result.Quantity))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Result.TotalPrice));


        }
    }
    
}
