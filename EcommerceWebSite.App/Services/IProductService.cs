using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.Product;
using System.Collections.Generic;
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
    }
}
