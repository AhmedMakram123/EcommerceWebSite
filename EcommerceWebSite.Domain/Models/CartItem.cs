using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.Models
{
    public class CartItem : BaseEntity
    {
        [Required(ErrorMessage = "Product Id Required")]
        public int ProductId { get; set; }
       
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
        //relation 
        [ForeignKey("Product")]
        [NotMapped]
        public Product Product { get; set; }
        [ForeignKey("Customer")]
        [Required(ErrorMessage = "Customer Id Required")]
        public string CustId { get; set; }
        [NotMapped]
        public Customer Customer { get; set; } 

    }
}
