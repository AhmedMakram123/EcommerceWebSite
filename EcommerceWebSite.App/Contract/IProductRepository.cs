using EcommerceWebSite.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Contract
{
    public interface IProductRepository : IBaseRepository<Product, int>
    {
        public Task<IQueryable<Product>> getAllProductByCategory(int CategoryId);
    }
}
