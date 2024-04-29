using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.CartItem;
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
		private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly ICartItemRepository _cartItemService;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public OrderService( IProductRepository productRepository, IOrderRepository orderRepository,IMapper mapper, IOrderDetailsRepository orderDetails,ICartItemRepository cartItem)
		{
			_orderRepository = orderRepository;
			_cartItemService = cartItem;
			_orderDetailsRepository = orderDetails;
			_mapper = mapper;
			_productRepository= productRepository;
			
		}

		public async Task<List<GetOrderDto>> GetAll()
		{
			var orders = await _orderRepository.GetAllAsync();
			var order=orders.Select(b => new GetOrderDto()
            {
                Id = b.Id,
                UserID = b.UserID,
                UserName = b.User.fName+ " "+b.User.lName,
				FinalPrice = b.FinalPrice,
				Date= b.Date,
				Address = b.Address,
				State=b.State,
               }).ToList();
            return order;
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
			var cart = await _cartItemService.GetAllAsync();
			var cartItems = cart.Select(b => new CreateOrUpdateCartItemDto()
			{
				Id = b.Id,
				CustId = b.CustId,
				ProductId = b.ProductId,
				Quantity = b.Quantity,
				TotalPrice = b.TotalPrice,
			}).ToList().Where(p => p.CustId == orderDto.UserID);
            order.OrderDetails = new List<OrderDetails>();
            foreach (var item in cartItems)
			{
                var p=await _productRepository.GetByIdAsync(item.ProductId);
				if (p.Quantity >= item.Quantity)
				{
					OrderDetailsDTO orderDetailsDto = new OrderDetailsDTO();
					orderDetailsDto.TotalPrice = item.TotalPrice;
					order.FinalPrice += orderDetailsDto.TotalPrice;
					orderDetailsDto.Quantity = item.Quantity;
					orderDetailsDto.ProductId = item.ProductId;
					var cart1 = _mapper.Map<CartItem>(item);
					await _cartItemService.DeleteAsync(cart1);
					await _cartItemService.SaveChangesAsync();
					var orderDetail = _mapper.Map<OrderDetails>(orderDetailsDto);
					order.OrderDetails.Add(orderDetail);
				}
			}  
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
				oldOrder.Address = newOrder.Address;
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
