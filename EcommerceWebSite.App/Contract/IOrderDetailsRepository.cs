using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Contract
{
	public interface IOrderDetailsRepository : IBaseRepository<OrderDetails, int>
    {
        Task<List<OrderDetailsDTO>> GetOrderDetails(int OId);


    }
}
