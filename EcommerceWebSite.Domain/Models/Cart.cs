using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.Models
{
    public class Cart : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        //relation 
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        [ForeignKey("Customer")]
        public string CustId { get; set; }
        public Customer Customer { get; set; } 

    }
}
