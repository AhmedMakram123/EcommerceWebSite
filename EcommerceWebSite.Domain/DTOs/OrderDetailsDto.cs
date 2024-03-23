namespace EcommerceWebSite.Domain.DTOs
{
	public class OrderDetailsDTO
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
		public int ProductId { get; set; }
        public int OrderId { get; set; }

    }
}
