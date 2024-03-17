using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.Models;
using EcommerceWebSite.Infrastractions.Repositores;

namespace EcommerceWebSite.Infrastractions.Repositories
{
	public class OrderDetailsRepository : BaseRepository<OrderDetails, int>, IOrderDetailsRepository
	{
		public OrderDetailsRepository(EcommerceContext EcommerceContext) : base(EcommerceContext)
		{
		}
	}
}
