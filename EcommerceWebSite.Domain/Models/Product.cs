using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.Models
{
    public class Product : BaseEntity
    {

        [Required(ErrorMessage = " Arabic name is required.")]
        [MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string ArName { get; set; }

        [Required(ErrorMessage = " English name is required.")]
        [MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string EnName { get; set; }
        [Required(ErrorMessage = "EnDescription is required.")]
        public string? EnDescription { get; set; }

        [Required(ErrorMessage = "ArDescription is required.")]
        public string ArDescription { get; set; }
        public string? imgURL { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
        public decimal PriceBeforeDiscount { get; set; }
        // relation 
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory? Category { get; set; }
        public List<OrderDetails>? OrderDetails { get; set; }
        public List<CartItem>? CartItem { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
