using EcommerceWebSite.Domain.DTOs;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public interface IOrderService
	{
		public Task<ResultDataList<OrderDTO>> GetAll();
		public Task<OrderDTO> GetOne(int id);
		public Task<ResultView<OrderDTO>> Create(OrderDTO order);
		public Task<OrderDTO> Update(int id, OrderDTO order);
		public Task<ResultView<OrderDTO>> Delete(OrderDTO order);
		public Task<ResultView<OrderDTO>> ConfirmOrder(int orderId);
		public Task<ResultView<OrderDTO>> CancelOrder(int orderId);
		public Task<int> Save();
	}
}
