using EcommerceWebSite.Domain.DTOs;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public interface IOrderDetailsService
	{
		Task<ResultDataList<OrderDetailsDTO>> GetAll();
		Task<OrderDetailsDTO> GetOne(int id);
		Task<ResultView<OrderDetailsDTO>> Create(OrderDetailsDTO orderDetails);
		Task<ResultView<OrderDetailsDTO>> Update(OrderDetailsDTO orderDetails);
		Task<ResultView<OrderDetailsDTO>> Delete(OrderDetailsDTO orderDetails);
		Task<int> Save();
	}
}
