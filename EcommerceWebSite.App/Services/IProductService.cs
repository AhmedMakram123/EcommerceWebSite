using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.Products;
using EcommerceWebSite.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public interface IProductService
    {
        public Task<List<GetAllProductDTO>> GetAll();
        public Task<GetAllProductDTO> GetOne(int id);
        public Task<ResultView<GetAllProductDTO>> Create(CreateOrUpdateProductDTO product);
        public Task<CreateOrUpdateProductDTO> Update(GetAllProductDTO product);
        public Task<ResultView<GetAllProductDTO>> Delete(int id);
        public Task<int> Save();
        public Task<List<Product>> getAllProductByCategory(int CategoryId);
    }
}
