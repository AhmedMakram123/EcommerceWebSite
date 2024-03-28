using System.ComponentModel.DataAnnotations;

namespace EcommerceWebSite.Domain.DTOs.Products
{
    public class GetAllProductDTO
    {
        public int id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string Description { get; set; }
        public string imgURL { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
    }
}
