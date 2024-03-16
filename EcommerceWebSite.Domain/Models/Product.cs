using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // relation 
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory? Category { get; set; }
        public List<OrderDetails>? OrderDetails { get; set; }
    }
}
