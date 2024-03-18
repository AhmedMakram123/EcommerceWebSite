namespace EcommerceWebSite.Domain.DTOs
{
    public class CreateOrUpdateProductDTO
    {
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
    }
}
