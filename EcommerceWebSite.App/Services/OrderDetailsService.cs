using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
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
			var orderDetail = _mapper.Map<OrderDetails>(orderDetailsDto);
			var createdOrderDetail = await _orderDetailsRepository.CreateAsync(orderDetail);
			await _orderDetailsRepository.SaveChangesAsync();
			return new ResultView<OrderDetailsDTO> { Entity = _mapper.Map<OrderDetailsDTO>(createdOrderDetail), IsSuccess = true, msg = "Created Successful" };
		}

		public async Task<ResultView<OrderDetailsDTO>> Update(OrderDetailsDTO orderDetailsDto)
		{
			var orderDetail = _mapper.Map<OrderDetails>(orderDetailsDto);
			var updatedOrderDetail = await _orderDetailsRepository.UpdateAsync(orderDetail);
			await _orderDetailsRepository.SaveChangesAsync();
			return new ResultView<OrderDetailsDTO> { Entity = _mapper.Map<OrderDetailsDTO>(updatedOrderDetail), IsSuccess = true, msg = "Updated Successful" };
			
		}

		public async Task<ResultView<OrderDetailsDTO>> Delete(OrderDetailsDTO orderDetailsDto)
		{
			var orderDetail = _mapper.Map<OrderDetails>(orderDetailsDto);
			var deletedOrderDetail = await _orderDetailsRepository.DeleteAsync(orderDetail);
			await _orderDetailsRepository.SaveChangesAsync();
			return new ResultView<OrderDetailsDTO> { Entity = _mapper.Map<OrderDetailsDTO>(deletedOrderDetail), IsSuccess = true, msg = "Deleted Successful" };
		}

		public async Task<int> Save()
		{
			var result = await _orderDetailsRepository.SaveChangesAsync();
			return (result);
		}
	}
}
