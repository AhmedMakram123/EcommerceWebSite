using EcommerceWebSite.Domain.DTOs;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public interface IOrderDetailsService
	{
		public Task<ResultDataList<OrderDetailsDTO>> GetAll();
		public Task<OrderDetailsDTO> GetOne(int id);
		public Task<ResultView<OrderDetailsDTO>> Create(OrderDetailsDTO orderDetails);
		public Task<OrderDetailsDTO> Update(int id ,OrderDetailsDTO orderDetails);
		public Task<ResultView<OrderDetailsDTO>> Delete(OrderDetailsDTO orderDetails);
		public Task<int> Save();
	}
}
