using EcommerceWebSite.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public decimal FinalPrice { get; set;}
        public DateTime Date { get; set;}
        public OrderState State { get; set;}
        public string UserID { get; set;}
        public string UserName { get; set;}
        public string Address { get; set; }

    }
}
