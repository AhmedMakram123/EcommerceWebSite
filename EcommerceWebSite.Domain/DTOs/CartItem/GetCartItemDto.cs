using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs.CartItem
{
    public class GetCartItemDto
    {
      public int Id { get; set; }
        public int ProductId { get; set; }
        public string CustId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
