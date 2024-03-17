using EcommerceWebSite.App.Services;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.CartItem;
using EcommerceWebSite.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    public class CartItemController : Controller
    {

        private ICartItemService CartItemService { get; }

        public CartItemController(ICartItemService CartItemService)
        {
            this.CartItemService = CartItemService;
        }
        [HttpGet]
        public async Task<ActionResult> GetCartItemAsync()
        {
            ResultDataList<CreateOrUpdateCartItemDto> category = await CartItemService.GetAll();
            return Ok(category.Entities);
        }
       
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            CreateOrUpdateCartItemDto C = await CartItemService.GetOne(id);
            return Ok(C);
        }

        [HttpPost]
        public async Task PostAsync([FromBody] CreateOrUpdateCartItemDto CartItemDto)
        {
            CreateOrUpdateCartItemDto CartItemDto1 = new CreateOrUpdateCartItemDto();
            CartItemDto1.Quantity = CartItemDto.Quantity;
            CartItemDto1.TotalPrice = CartItemDto.TotalPrice;
            _ = await CartItemService.Create(CartItemDto1);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CreateOrUpdateCartItemDto CartItemDto)
        {
            CreateOrUpdateCartItemDto c1 = await CartItemService.GetOne(id);

            c1.Quantity = CartItemDto.Quantity;
            c1.TotalPrice= CartItemDto.TotalPrice;

            await CartItemService.Update(c1);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromBody] CreateOrUpdateCartItemDto c)
        {
            await CartItemService.Delete(c);
            return Ok();
        }

    }
}
