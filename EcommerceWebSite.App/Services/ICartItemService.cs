using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public interface ICartItemService
    {
        public Task<ResultDataList<CreateOrUpdateCartItemDto>> GetAll();
        public Task<CreateOrUpdateCartItemDto> GetOne(int id);
        public Task<ResultView<CreateOrUpdateCartItemDto>> Create(CreateOrUpdateCartItemDto CartItemDto);
        public Task<ResultView<CreateOrUpdateCartItemDto>> Update(CreateOrUpdateCartItemDto CartItemDto);
        public Task<ResultView<CreateOrUpdateCartItemDto>> Delete(CreateOrUpdateCartItemDto CartItemDto);
        public Task<int> Save();


    }
}
