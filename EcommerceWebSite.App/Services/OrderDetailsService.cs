using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.CartItem;
using EcommerceWebSite.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public class OrderDetailsService : IOrderDetailsService
	{
		private readonly IOrderDetailsRepository _orderDetailsRepository;
		private readonly IMapper _mapper;

		public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
		{
			_orderDetailsRepository = orderDetailsRepository;
			_mapper = mapper;
		}

		public async Task<List<OrderDetailsDTO>> GetAll()
		{
			var orderDetails = await _orderDetailsRepository.GetAllAsync();
			return _mapper.Map<List<OrderDetailsDTO>>(orderDetails);
		}

		public async Task<OrderDetailsDTO> GetOne(int id)
		{
			var orderDetail = await _orderDetailsRepository.GetByIdAsync(id);
			return _mapper.Map<OrderDetailsDTO>(orderDetail);
		}

		public async Task<ResultView<OrderDetailsDTO>> Create(OrderDetailsDTO orderDetailsDto)
		{
            var query = await _orderDetailsRepository.GetAllAsync();
            var Old = query.Where(p => p.OrderId == orderDetailsDto.OrderId)
				.FirstOrDefault();
            if (Old != null)
            {
                return new ResultView<OrderDetailsDTO> { Entity = null, IsSuccess = false, msg = "Already Exists" };
            }
            else
            {
                var o = _mapper.Map<OrderDetails>(orderDetailsDto);
                var New = await _orderDetailsRepository.CreateAsync(o);
                await _orderDetailsRepository.SaveChangesAsync();
                var p = _mapper.Map<OrderDetailsDTO>(New);
                return new ResultView<OrderDetailsDTO> { Entity = p, IsSuccess = true, msg = "Created Successful" };
            }
        }


		public async Task<OrderDetailsDTO> Update(int id, OrderDetailsDTO orderDetailsDto)
		{
			var oldOrderDetails = await _orderDetailsRepository.GetByIdAsync(id);
			if (oldOrderDetails == null)
			{

				return null;
			}
			else { 
			var newOrderDetails = _mapper.Map<OrderDetails>(orderDetailsDto);
			oldOrderDetails.Quantity=newOrderDetails.Quantity;
			oldOrderDetails.TotalPrice=newOrderDetails.TotalPrice;
			oldOrderDetails.ProductId=newOrderDetails.ProductId;
			var updatedOrderDetails = await _orderDetailsRepository.UpdateAsync(oldOrderDetails);
			await _orderDetailsRepository.SaveChangesAsync();
			return _mapper.Map<OrderDetailsDTO>(updatedOrderDetails);
            }


        }

		public async Task<ResultView<OrderDetailsDTO>> Delete(int Id)
		{
            var oldOrder = await _orderDetailsRepository.GetByIdAsync(Id);
            if (oldOrder != null)
            {
                var deletedOrder = await _orderDetailsRepository.DeleteAsync(oldOrder);
                await _orderDetailsRepository.SaveChangesAsync();
                return new ResultView<OrderDetailsDTO> { Entity = _mapper.Map<OrderDetailsDTO>(deletedOrder), IsSuccess = true, msg = "Deleted Successful" };
            }
            return new ResultView<OrderDetailsDTO>
            {
                IsSuccess = false,
                msg = "Order not found"
            };
            
		}

		public async Task<int> Save()
		{
			var result = await _orderDetailsRepository.SaveChangesAsync();
			return result;
		}
	}
}
