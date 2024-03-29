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
			order.FinalPrice = 0;
			var createdOrder = await _orderRepository.CreateAsync(order);
			await _orderRepository.SaveChangesAsync();
			return new ResultView<OrderDTO> { Entity = _mapper.Map<OrderDTO>(createdOrder), IsSuccess = true, msg = "Created Successful" };
		}

		public async Task<OrderDTO> Update(int id, OrderDTO orderDto)
		{
			var oldOrder = await _orderRepository.GetByIdAsync(id);
			if (oldOrder != null)
			{
                var newOrder = _mapper.Map<Order>(orderDto);
                oldOrder.State = newOrder.State;
                oldOrder.Date = newOrder.Date;
                var updatedOrder = await _orderRepository.UpdateAsync(oldOrder);
                await _orderRepository.SaveChangesAsync();
                return _mapper.Map<OrderDTO>(updatedOrder);
            }
			else
			{
				return null; 
			}

        }

		public async Task<ResultView<OrderDTO>> Delete(int Id)
		{
			var oldOrder = await _orderRepository.GetByIdAsync(Id);
			if (oldOrder != null)
			{
				var deletedOrder = await _orderRepository.DeleteAsync(oldOrder);

                await _orderRepository.SaveChangesAsync();
				return new ResultView<OrderDTO> { Entity = _mapper.Map<OrderDTO>(deletedOrder), IsSuccess = true, msg = "Deleted Successful" };
			}
            return new ResultView<OrderDTO>
            {
                IsSuccess = false,
                msg = "Order not found"
            };
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
			return result;
		}

        public async Task<List<OrderDTO>> GetUserOrdars(string Id)
        {
            var orders = await _orderRepository.GetAllAsync();
            var orders2 = orders.Where(e=>e.UserID==Id);
            return _mapper.Map<List<OrderDTO>>(orders2);
        }
    }
}
