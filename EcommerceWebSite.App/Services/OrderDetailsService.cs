﻿using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
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

		public async Task<ResultDataList<OrderDetailsDTO>> GetAll()
		{
			var orderDetails = await _orderDetailsRepository.GetAllAsync();
			return _mapper.Map< ResultDataList<OrderDetailsDTO>>(orderDetails);
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


		public async Task<OrderDetailsDTO> Update(int id, OrderDetailsDTO orderDetailsDto)
		{
			var oldOrderDetails = await _orderDetailsRepository.GetByIdAsync(id);
			if (oldOrderDetails == null)
			{

				return null;
			}
			var newOrderDetails = _mapper.Map<OrderDetails>(orderDetailsDto);
			oldOrderDetails.Quantity=newOrderDetails.Quantity;
			oldOrderDetails.TotalPrice=newOrderDetails.TotalPrice;
			oldOrderDetails.ProductId=newOrderDetails.ProductId;

			var updatedOrderDetails = await _orderDetailsRepository.UpdateAsync(oldOrderDetails);
			await _orderDetailsRepository.SaveChangesAsync();
			return _mapper.Map<OrderDetailsDTO>(updatedOrderDetails);


			
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
			return result;
		}
	}
}
