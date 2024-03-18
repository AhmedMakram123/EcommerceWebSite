using EcommerceWebSite.Domain.Enum;
using System;
using System.Collections.Generic;

namespace EcommerceWebSite.Domain.DTOs
{
	public class OrderDTO
	{
		public decimal FinalPrice { get; set; }
		public DateTime Date { get; set; }
		public OrderState State { get; set; }
		public string UserID { get; set; }
		public List<OrderDetailsDTO> OrderDetails { get; set; }
	}
}
