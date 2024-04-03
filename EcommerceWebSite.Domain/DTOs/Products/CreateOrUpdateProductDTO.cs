using System.ComponentModel.DataAnnotations;

namespace EcommerceWebSite.Domain.DTOs.Products
{
    public class CreateOrUpdateProductDTO
    {
      public int id { get; set; }
        [Required(ErrorMessage = " English name is required."), MaxLength(100, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string ArName { get; set; }
        [Required(ErrorMessage = " Arabic name is required."), MaxLength(100, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string EnName { get; set; }
        [Required(ErrorMessage = "description is required.")]
        public string Description { get; set; }
        public string imgURL { get; set; }
        public string? imgURLAr { get; set; }
        [Required(ErrorMessage = "Quantity is required."), Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required."), Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
    }
}
