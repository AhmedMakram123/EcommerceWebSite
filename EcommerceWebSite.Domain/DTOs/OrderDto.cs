using EcommerceWebSite.Domain.Enum;
using System;
using System.Collections.Generic;

namespace EcommerceWebSite.Domain.DTOs
{
	public class OrderDTO
	{
		public int Id {  get; set; } 
		public decimal FinalPrice { get; set; }
		public DateTime Date { get; set; }
		public OrderState State { get; set; }
		public string UserID { get; set; }
        public string Address { get; set; }	

    }
}
