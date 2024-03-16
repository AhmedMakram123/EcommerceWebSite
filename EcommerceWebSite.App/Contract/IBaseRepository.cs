using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Contract
{
    public interface IBaseRepository<TEntity, TId>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TId id);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<int> SaveChangesAsync();
    }
}
