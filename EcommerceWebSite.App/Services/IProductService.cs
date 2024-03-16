using EcommerceWebSite.Domain.DTOs;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public interface IProductService
    {
        public Task<CreateOrUpdateProductDTO> GetAll();
        public Task<CreateOrUpdateProductDTO> GetOne(int id);
        public Task<ResultView<CreateOrUpdateProductDTO>> Create(CreateOrUpdateProductDTO product);
        public Task<CreateOrUpdateProductDTO> Update(CreateOrUpdateProductDTO product);
        public Task<ResultView<CreateOrUpdateProductDTO>> Delete(CreateOrUpdateProductDTO product);
        public Task<CreateOrUpdateProductDTO> Save();
    }
}
