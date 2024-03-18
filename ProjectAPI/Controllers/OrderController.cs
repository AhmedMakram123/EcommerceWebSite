using EcommerceWebSite.App.Services;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllOrders()
		{
			var orders = await _orderService.GetAll();
			return Ok(orders);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetOrderById(int id)
		{
			var order = await _orderService.GetOne(id);
			return Ok(order);
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDTO)
		{
			// Set initial state for a new order
			orderDTO.State = OrderState.Pending;

			var result = await _orderService.Create(orderDTO);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDTO orderDTO)
		{
			var order = await _orderService.GetOne(id);
			if (order == null)
			{
				return NotFound();
			}

			var updatedOrder = await _orderService.Update(orderDTO);
			return Ok(updatedOrder);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOrder(int id)
		{
			var order = await _orderService.GetOne(id);
			if (order == null)
			{
				return NotFound();
			}

			var result = await _orderService.Delete(order);
			return Ok(result);
		}

		[HttpPut("{id}/confirm")]
		public async Task<IActionResult> ConfirmOrder(int id)
		{
			var result = await _orderService.ConfirmOrder(id);
			if (!result.IsSuccess)
			{
				return BadRequest(result.msg);
			}

			return Ok(result.Entity);
		}

		[HttpPut("{id}/cancel")]
		public async Task<IActionResult> CancelOrder(int id)
		{
			var result = await _orderService.CancelOrder(id);
			if (!result.IsSuccess)
			{
				return BadRequest(result.msg);
			}

			return Ok(result.Entity);
		}
	}
}
