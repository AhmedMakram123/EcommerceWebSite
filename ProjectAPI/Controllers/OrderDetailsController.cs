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
		public async Task<IActionResult> CreateOrderDetails([FromBody] OrderDetailsDTO orderDetailsDTO)
		{
			var result = await _orderDetailsService.Create(orderDetailsDTO);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateOrderDetails(int id, [FromBody] OrderDetailsDTO orderDetailsDTO)
		{
			var orderDetail = await _orderDetailsService.GetOne(id);
			if (orderDetail == null)
			{
				return NotFound();
			}

			var updatedOrderDetail = await _orderDetailsService.Update(orderDetailsDTO);
			return Ok(updatedOrderDetail);
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
