using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
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

		public async Task<OrderDTO> GetAll()
		{
			var orders = await _orderRepository.GetAllAsync();
			return _mapper.Map<OrderDTO>(orders);
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

		public async Task<OrderDTO> Update(OrderDTO orderDto)
		{
			var order = _mapper.Map<Order>(orderDto);
			var updatedOrder = await _orderRepository.UpdateAsync(order);
			return _mapper.Map<OrderDTO>(updatedOrder);
		}

		public async Task<ResultView<OrderDTO>> Delete(OrderDTO orderDto)
		{
			var order = _mapper.Map<Order>(orderDto);
			var deletedOrder = await _orderRepository.DeleteAsync(order);
			await _orderRepository.SaveChangesAsync();
			return new ResultView<OrderDTO> { Entity = _mapper.Map<OrderDTO>(deletedOrder), IsSuccess = true, msg = "Deleted Successful" };
		}

		public async Task<OrderDTO> Save()
		{
			var result = await _orderRepository.SaveChangesAsync();
			return _mapper.Map<OrderDTO>(result);
		}
	}
}
