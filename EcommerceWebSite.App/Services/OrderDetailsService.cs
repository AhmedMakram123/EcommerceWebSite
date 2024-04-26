using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.CartItem;
using EcommerceWebSite.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
	public class OrderDetailsService : IOrderDetailsService
	{
		private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapper _mapper;

		public OrderDetailsService(IProductRepository _product, IOrderRepository orderRepository, IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
		{
			_orderDetailsRepository = orderDetailsRepository;
			_mapper = mapper;
			productRepository = _product; 
            _orderRepository = orderRepository;

		}

		public async Task<List<GetOrderDetailsDTO>> GetAll()
		{
			var orderDetails = await _orderDetailsRepository.GetAllAsync();
            //return _mapper.Map<List<OrderDetailsDTO>>(orderDetails);
            List < GetOrderDetailsDTO > getDetailsDTOs= orderDetails.Select
               ( e => new GetOrderDetailsDTO()
                {
                    Id = e.Id,
                    ProductId = e.ProductId,
                    Quantity = e.Quantity,
                    TotalPrice = e.TotalPrice,
                    ProductName= e.Product.EnName,
                    orderId=e.OrderId
               }).ToList();
            return getDetailsDTOs;
        }

		public async Task<OrderDetailsDTO> GetOne(int id)
		{
			var orderDetail = await _orderDetailsRepository.GetByIdAsync(id);
			return _mapper.Map<OrderDetailsDTO>(orderDetail);
		}

		public async Task<ResultView<OrderDetailsDTO>> Create(OrderDetailsDTO orderDetailsDto)
		{
            var query = await _orderDetailsRepository.GetAllAsync();
            var Old = query.Where(p => p.OrderId == orderDetailsDto.OrderId&&(p.ProductId==orderDetailsDto.ProductId))
				.FirstOrDefault();
            if (Old != null)
            {
                return new ResultView<OrderDetailsDTO> { Entity = null, IsSuccess = false, msg = "Already Exists" };
            }
            else
            {
                var o = _mapper.Map<OrderDetails>(orderDetailsDto);
                var New = await _orderDetailsRepository.CreateAsync(o);
                var prd = await productRepository.GetByIdAsync(New.ProductId);
				prd.Quantity -= New.Quantity;
                if (prd.PriceBeforeDiscount > 0)
                {
                    New.TotalPrice = prd.Price * New.Quantity * (100 - prd.PriceBeforeDiscount) / 100;
                }
                else
                {
                    New.TotalPrice = prd.Price * New.Quantity;
                }

                var order = await _orderRepository.GetByIdAsync(New.OrderId);
                order.FinalPrice += New.TotalPrice;

                await _orderDetailsRepository.SaveChangesAsync();
                var p = _mapper.Map<OrderDetailsDTO>(New);
                return new ResultView<OrderDetailsDTO> { Entity = p, IsSuccess = true, msg = "Created Successful" };
            }
        }


		public async Task<OrderDetailsDTO> Update(int id, OrderDetailsDTO orderDetailsDto)
		{
			var oldOrderDetails = await _orderDetailsRepository.GetByIdAsync(id);
			if (oldOrderDetails == null)
			{

				return null;
			}
			else { 
			var newOrderDetails = _mapper.Map<OrderDetails>(orderDetailsDto);
            var prd = await productRepository.GetByIdAsync(oldOrderDetails.ProductId);
            prd.Quantity += oldOrderDetails.Quantity;
            var order = await _orderRepository.GetByIdAsync(orderDetailsDto.OrderId);
            order.FinalPrice -= oldOrderDetails.TotalPrice;
            var prd2 = await productRepository.GetByIdAsync(newOrderDetails.ProductId);
            prd2.Quantity -= newOrderDetails.Quantity;
            oldOrderDetails.Quantity=newOrderDetails.Quantity;
                if (prd2.PriceBeforeDiscount > 0)
                {

                    oldOrderDetails.TotalPrice = (oldOrderDetails.Quantity * prd2.Price)* (100 - prd2.PriceBeforeDiscount) / 100;
                }
                else
                {
                    oldOrderDetails.TotalPrice = (oldOrderDetails.Quantity * prd2.Price);
                }

            

            order.FinalPrice += oldOrderDetails.TotalPrice;
            oldOrderDetails.ProductId=newOrderDetails.ProductId;
            var updatedOrderDetails = await _orderDetailsRepository.UpdateAsync(oldOrderDetails);
			await _orderDetailsRepository.SaveChangesAsync();
			return _mapper.Map<OrderDetailsDTO>(updatedOrderDetails);
            }
        }

		public async Task<ResultView<OrderDetailsDTO>> Delete(int Id)
		{
            var oldOrder = await _orderDetailsRepository.GetByIdAsync(Id);
            if (oldOrder != null)
            {
                var deletedOrder = await _orderDetailsRepository.DeleteAsync(oldOrder);
                var order = await _orderRepository.GetByIdAsync(deletedOrder.OrderId);
                order.FinalPrice -= deletedOrder.TotalPrice;
                var prd = await productRepository.GetByIdAsync(deletedOrder.ProductId);
                prd.Quantity += deletedOrder.Quantity;
                await _orderDetailsRepository.SaveChangesAsync();
                return new ResultView<OrderDetailsDTO> { Entity = _mapper.Map<OrderDetailsDTO>(deletedOrder), IsSuccess = true, msg = "Deleted Successful" };
            }
            return new ResultView<OrderDetailsDTO>
            {
                IsSuccess = false,
                msg = "Order Details  not found"
            };
            
		}

		public async Task<int> Save()
		{
			var result = await _orderDetailsRepository.SaveChangesAsync();
			return result;
		}

        public async Task<List<GetOrderDetailsDTO>> GetOrderDetails(int OId)
        {
            var orderDetails = await _orderDetailsRepository.GetAllAsync();
            var orderDetails2 = orderDetails.Where(e=> e.OrderId == OId);
            List<GetOrderDetailsDTO> getDetailsDTOs = orderDetails2.Select
              (e => new GetOrderDetailsDTO()
              {
                  Id = e.Id,
                  ProductId = e.ProductId,
                  Quantity = e.Quantity,
                  TotalPrice = e.TotalPrice,
                  ProductName = e.Product.EnName,
                  orderId = e.OrderId
              }).ToList();
            return getDetailsDTOs;
        }
    }
}
