using System.ComponentModel.DataAnnotations;

namespace EcommerceWebSite.Domain.DTOs.Products
{
    public class GetAllProductDTO
    {
        public int id { get; set; }
        public string enName { get; set; }
        public string arName { get; set; }
        public string description { get; set; }
        public string imgURL { get; set; }
        public int Quantity { get; set; }
        public decimal price { get; set; }
        public int SubCategoryId { get; set; }
    }
}
