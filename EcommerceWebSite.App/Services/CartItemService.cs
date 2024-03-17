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
        private readonly IMapper mapper;
        public CartItemService(ICartItemRepository _CartItem, IMapper _mapper )
        {
            this.cartItemService = _CartItem;
            this.mapper = _mapper;
        }

        public async Task<ResultView<CreateOrUpdateCartItemDto>> Create(CreateOrUpdateCartItemDto CartItemDto)
        {
            var query = await cartItemService.GetAllAsync();
            var OldCat = query.Where(p => p.CustId == CartItemDto.CustId && p.ProductId== CartItemDto.ProductId).FirstOrDefault();
            if (OldCat != null)
            {
                return new ResultView<CreateOrUpdateCartItemDto> { Entity = null, IsSuccess = false, msg = "Already Exists" };
            }
            else
            {
                var Cat = mapper.Map<CartItem>(CartItemDto);
                var NewCat = await cartItemService.CreateAsync(Cat);
                await cartItemService.SaveChangesAsync();
                var p = mapper.Map<CreateOrUpdateCartItemDto>(NewCat);
                return new ResultView<CreateOrUpdateCartItemDto> { Entity = p, IsSuccess = true, msg = "Created Successful" };
            }
        }

        public async Task<ResultView<CreateOrUpdateCartItemDto>> Delete(CreateOrUpdateCartItemDto CartItemDto)
        {
            var cat = mapper.Map<CartItem>(CartItemDto);
            var OldCat = cartItemService.DeleteAsync(cat);
            await cartItemService.SaveChangesAsync();
            var p = mapper.Map<CreateOrUpdateCartItemDto>(OldCat);
            return new ResultView<CreateOrUpdateCartItemDto> { Entity = p, IsSuccess = true, msg = "Deleted Successful" };

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
                old.TotalPrice = b.TotalPrice;
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
