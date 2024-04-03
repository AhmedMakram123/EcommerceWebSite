using EcommerceWebSite.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public interface IOrderDetailsService
	{
		public Task<List<GetOrderDetailsDTO>> GetAll();
        public Task<List<GetOrderDetailsDTO>> GetOrderDetails(int OId);
        public Task<OrderDetailsDTO> GetOne(int id);
		public Task<ResultView<OrderDetailsDTO>> Create(OrderDetailsDTO orderDetails);
		public Task<OrderDetailsDTO> Update(int id ,OrderDetailsDTO orderDetails);
		public Task<ResultView<OrderDetailsDTO>> Delete(int Id);
		public Task<int> Save();
	}
}
