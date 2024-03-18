using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Enum;
using EcommerceWebSite.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;

		public OrderService(IOrderRepository orderRepository, IMapper mapper)
		{
			_orderRepository = orderRepository;
			_mapper = mapper;
		}

		public async Task<List<OrderDTO>> GetAll()
		{
			var orders = await _orderRepository.GetAllAsync();
			return _mapper.Map<List<OrderDTO>>(orders);
		}

		public async Task<OrderDTO> GetOne(int id)
		{
			var order = await _orderRepository.GetByIdAsync(id);
			return _mapper.Map<OrderDTO>(order);
		}

		public async Task<ResultView<OrderDTO>> Create(OrderDTO orderDto)
		{
			var order = _mapper.Map<Order>(orderDto);
			var createdOrder = await _orderRepository.CreateAsync(order);
			await _orderRepository.SaveChangesAsync();
			return new ResultView<OrderDTO> { Entity = _mapper.Map<OrderDTO>(createdOrder), IsSuccess = true, msg = "Created Successful" };
		}

		public async Task<ResultView<OrderDTO>> Update(OrderDTO orderDto)
		{
			var order = _mapper.Map<Order>(orderDto);
			var updatedOrder = await _orderRepository.UpdateAsync(order);
			await _orderRepository.SaveChangesAsync();
			return new ResultView<OrderDTO> { Entity = _mapper.Map<OrderDTO>(updatedOrder), IsSuccess = true, msg = "Updated Successful" };
			
		}

		public async Task<ResultView<OrderDTO>> Delete(OrderDTO orderDto)
		{
			var order = _mapper.Map<Order>(orderDto);
			var deletedOrder = await _orderRepository.DeleteAsync(order);
			await _orderRepository.SaveChangesAsync();
			return new ResultView<OrderDTO> { Entity = _mapper.Map<OrderDTO>(deletedOrder), IsSuccess = true, msg = "Deleted Successful" };
		}


		public async Task<ResultView<OrderDTO>> ConfirmOrder(int orderId)
		{
			var order = await _orderRepository.GetByIdAsync(orderId);
			if (order == null)
			{
				return new ResultView<OrderDTO> { IsSuccess = false, msg = "Order is not found" };
			}

			// Check if the order is in a state that allows confirmation
			if (order.State != OrderState.Pending)
			{
				return new ResultView<OrderDTO> { IsSuccess = false, msg = "Order cannot be confirmed" };
			}

			order.State = OrderState.Confirmed;
			var updatedOrder = await _orderRepository.UpdateAsync(order);
			await _orderRepository.SaveChangesAsync();
			return new ResultView<OrderDTO> { Entity = _mapper.Map<OrderDTO>(updatedOrder), IsSuccess = true, msg = "Order confirmed successfully" };
		}

		public async Task<ResultView<OrderDTO>> CancelOrder(int orderId)
		{
			var order = await _orderRepository.GetByIdAsync(orderId);
			if (order == null)
			{
				return new ResultView<OrderDTO> { IsSuccess = false, msg = "Order is not found" };
			}

			// Check if the order is in a state that allows cancellation
			if (order.State != OrderState.Pending && order.State != OrderState.Confirmed)
			{
				return new ResultView<OrderDTO> { IsSuccess = false, msg = "Order cannot be canceled" };
			}

			order.State = OrderState.Canceled;
			var updatedOrder = await _orderRepository.UpdateAsync(order);
			await _orderRepository.SaveChangesAsync();
			return new ResultView<OrderDTO> { Entity = _mapper.Map<OrderDTO>(updatedOrder), IsSuccess = true, msg = "Order canceled successfully" };
		}


		public async Task<int> Save()
		{
			var result = await _orderRepository.SaveChangesAsync();
			return (result);
		}
	}
}
