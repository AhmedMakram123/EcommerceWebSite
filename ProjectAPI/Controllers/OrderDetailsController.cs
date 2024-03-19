using EcommerceWebSite.App.Services;
using EcommerceWebSite.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly IOrderDetailsService _orderDetailsService;

		public OrderDetailsController(IOrderDetailsService orderDetailsService)
		{
			_orderDetailsService = orderDetailsService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllOrderDetails()
		{
			var orderDetails = await _orderDetailsService.GetAll();
			return Ok(orderDetails);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetOrderDetailsById(int id)
		{
			var orderDetail = await _orderDetailsService.GetOne(id);
			return Ok(orderDetail);
		}

		[HttpPost]
		public async Task CreateOrderDetails([FromBody] OrderDetailsDTO orderDetailsDTO)
		{
			OrderDetailsDTO orderDetailsDTO1 = new OrderDetailsDTO();
			orderDetailsDTO1.Quantity = orderDetailsDTO.Quantity;
			orderDetailsDTO1.TotalPrice = orderDetailsDTO.TotalPrice;
			orderDetailsDTO1.ProductId = orderDetailsDTO.ProductId;
			_ = await _orderDetailsService.Create(orderDetailsDTO1);

			
		}

		[HttpPut("{id}")]
		public async Task UpdateOrderDetails(int id, [FromBody] OrderDetailsDTO orderDetailsDTO)
		{
			OrderDetailsDTO orderDetails = await _orderDetailsService.GetOne(id);
			orderDetails.Quantity = orderDetailsDTO.Quantity;
			orderDetails.TotalPrice = orderDetailsDTO.TotalPrice;
			orderDetails.ProductId = orderDetailsDTO.ProductId;
			_ = await _orderDetailsService.Create(orderDetails);

			
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOrderDetails(int id)
		{
			var orderDetail = await _orderDetailsService.GetOne(id);
			if (orderDetail == null)
			{
				return NotFound();
			}

			var result = await _orderDetailsService.Delete(orderDetail);
			return Ok(result);
		}
	}
}
