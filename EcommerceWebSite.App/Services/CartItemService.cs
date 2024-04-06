using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceWebSite.Domain.DTOs.CartItem;
using AutoMapper;
using EcommerceWebSite.Domain.DTOs;
namespace EcommerceWebSite.App.Services
{
    public class CartItemService : ICartItemService
    {

        private readonly ICartItemRepository cartItemService;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public CartItemService(ICartItemRepository _CartItem, IMapper _mapper , IProductRepository _product)
        {
            this.cartItemService = _CartItem;
            this.mapper = _mapper;
            this.productRepository=_product;
        }

        public async Task<ResultView<CreateOrUpdateCartItemDto>> Create(CreateOrUpdateCartItemDto CartItemDto)
        {
            var query = await cartItemService.GetAllAsync();
            var OldCat = query.Where(p => p.CustId == CartItemDto.CustId && p.ProductId== CartItemDto.ProductId).FirstOrDefault();
            var Cat = mapper.Map<CartItem>(CartItemDto);
            var p = await productRepository.GetByIdAsync(CartItemDto.ProductId);
            Cat.TotalPrice = p.Price * Cat.Quantity;

            if (OldCat != null)
            {
                await cartItemService.UpdateAsync(Cat);
                return new ResultView<CreateOrUpdateCartItemDto> { Entity = null, IsSuccess = false, msg = "Already Exists" };
            }
            else
            {
                var NewCat = await cartItemService.CreateAsync(Cat);
                await cartItemService.SaveChangesAsync();
                var c = mapper.Map<CreateOrUpdateCartItemDto>(NewCat);
                return new ResultView<CreateOrUpdateCartItemDto> { Entity = c, IsSuccess = true, msg = "Created Successful" };
            }
        }

        public async Task<ResultView<CreateOrUpdateCartItemDto>> Delete(int Id)
        {
            var cat = await cartItemService.GetByIdAsync(Id);
            if (cat == null)
            {
                return new ResultView<CreateOrUpdateCartItemDto> 

                {
                    IsSuccess = false,
                    msg = "CartItem not found"
                };
            }
            else { 
            var OldCat = cartItemService.DeleteAsync(cat);
            await cartItemService.SaveChangesAsync();
            var p = mapper.Map<CreateOrUpdateCartItemDto>(OldCat);
            return new ResultView<CreateOrUpdateCartItemDto> { Entity = p, IsSuccess = true, msg = "Deleted Successful" };
            }
        }

        public async Task<ResultDataList<CreateOrUpdateCartItemDto>> GetAll()
        {
            var cats = await cartItemService.GetAllAsync();
            var cat = cats
                .Select(b => new CreateOrUpdateCartItemDto()
                {
                    Id = b.Id,
                    CustId = b.CustId,
                    ProductId = b.ProductId,
                    Quantity = b.Quantity,
                    TotalPrice= b.TotalPrice
                }).ToList();
            ResultDataList<CreateOrUpdateCartItemDto> resultDataList = new ResultDataList<CreateOrUpdateCartItemDto>();
            resultDataList.Entities = cat.ToList();
            resultDataList.Count = cats.Count();
            return resultDataList;


            
        }

        public async Task<CreateOrUpdateCartItemDto> GetOne(int id)
        {
            var cat = await cartItemService.GetByIdAsync(id);
            return mapper.Map<CreateOrUpdateCartItemDto>(cat);

        }

        public async Task<int> Save()
        {
            var res = await cartItemService.SaveChangesAsync();
            return res;
            
        }

        public async Task<ResultView<CreateOrUpdateCartItemDto>> Update(CreateOrUpdateCartItemDto CartItemDto)
        {
            var Query = (await cartItemService.GetAllAsync());
            var old = Query.Where(e => e.ProductId == CartItemDto.ProductId&&e.CustId==CartItemDto.CustId).FirstOrDefault();
            if (old != null)
            {
                var b = mapper.Map<CartItem>(CartItemDto);
                old.Quantity= b.Quantity;
                var p = await productRepository.GetByIdAsync(CartItemDto.ProductId);
                old.TotalPrice = p.Price * old.Quantity;
                var NewBook = await cartItemService.UpdateAsync(old);
                await cartItemService.SaveChangesAsync();
                var bDto = mapper.Map<CreateOrUpdateCartItemDto>(NewBook);

                return new ResultView<CreateOrUpdateCartItemDto> { Entity = bDto, IsSuccess = true, msg = "updated successfully" };
            }
            else
            {
                return new ResultView<CreateOrUpdateCartItemDto> { Entity = null, IsSuccess = false, msg = "Already Exist" };

            }



        }
    }
}
