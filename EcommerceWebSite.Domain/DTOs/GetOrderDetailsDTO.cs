using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class GetOrderDetailsDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int orderId { get; set; }
        public string ProductName { get; set; }
    }
}
