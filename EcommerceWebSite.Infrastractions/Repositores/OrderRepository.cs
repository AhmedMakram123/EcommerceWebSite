using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.Models;
using EcommerceWebSite.Infrastractions.Repositores;

namespace EcommerceWebSite.Infrastractions.Repositories
{
	public class OrderRepository : BaseRepository<Order, int>, IOrderRepository
	{
		public OrderRepository(EcommerceContext EcommerceContext) : base(EcommerceContext)
		{
		}
	}
}
