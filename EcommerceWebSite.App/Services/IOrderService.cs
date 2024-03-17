using EcommerceWebSite.Domain.DTOs;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public interface IOrderService
	{
		Task<OrderDTO> GetAll();
		Task<OrderDTO> GetOne(int id);
		Task<ResultView<OrderDTO>> Create(OrderDTO order);
		Task<OrderDTO> Update(OrderDTO order);
		Task<ResultView<OrderDTO>> Delete(OrderDTO order);
		Task<OrderDTO> Save();
	}
}
