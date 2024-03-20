using System.ComponentModel.DataAnnotations;

namespace EcommerceWebSite.Domain.DTOs.Product
{
    public class CreateOrUpdateProductDTO
    {
        [Required(ErrorMessage = " English name is required."), MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string enName { get; set; }
        [Required(ErrorMessage = " Arabic name is required."), MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string arName { get; set; }
        [Required(ErrorMessage = "description is required.")]
        public string description { get; set; }
        public string imgURL { get; set; }
        [Required(ErrorMessage = "Quantity is required."), Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required."), Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal price { get; set; }
        public int SubCategoryId { get; set; }
    }
}
