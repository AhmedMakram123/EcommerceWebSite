using EcommerceWebSite.Domain.DTOs;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public interface IOrderDetailsService
	{
		Task<OrderDetailsDTO> GetAll();
		Task<OrderDetailsDTO> GetOne(int id);
		Task<ResultView<OrderDetailsDTO>> Create(OrderDetailsDTO orderDetails);
		Task<OrderDetailsDTO> Update(OrderDetailsDTO orderDetails);
		Task<ResultView<OrderDetailsDTO>> Delete(OrderDetailsDTO orderDetails);
		Task<OrderDetailsDTO> Save();
	}
}
