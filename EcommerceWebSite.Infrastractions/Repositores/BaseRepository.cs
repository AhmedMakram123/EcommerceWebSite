using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.Infrastractions.Repositores
{
    //public class BaseRepository<TEntity, Tid> : IBaseRepository<TEntity, Tid> where TEntity : BaseEntity
    //{
    //    private readonly EcommerceContext _EcommerceContext;
    //    private readonly DbSet<TEntity> _Dbset;
    //    public BaseRepository(EcommerceContext EcommerceContext)
    //    {
    //        _EcommerceContext = EcommerceContext;
    //        _Dbset = _EcommerceContext.Set<TEntity>();
    //    }

    //    public async Task<TEntity> CreateAsync(TEntity entity)
    //    {
    //        return (await _Dbset.AddAsync(entity)).Entity;
    //    }

    //    public Task<TEntity> DeleteAsync(TEntity entity)
    //    {

    //        return Task.FromResult((_Dbset.Remove(entity)).Entity);
    //    }

    //    public Task<IQueryable<TEntity>> GetAllAsync()
    //    {
    //        return Task.FromResult(_Dbset.Select(s => s));
    //    }

    //    public async Task<TEntity> GetByIdAsync(Tid id)
    //    {
    //        return await _Dbset.FindAsync(id);
    //    }

    //    public async Task<int> SaveChangesAsync()
    //    {
    //        return await _EcommerceContext.SaveChangesAsync();
    //    }

    //    public Task<TEntity> UpdateAsync(TEntity entity)
    //    {
    //        return Task.FromResult(_Dbset.Update(entity).Entity);

    //    }

    //    Task<TEntity> IBaseRepository<TEntity, Tid>.CreateAsync(TEntity entity)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    Task<TEntity> IBaseRepository<TEntity, Tid>.DeleteAsync(TEntity entity)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    Task<IQueryable<TEntity>> IBaseRepository<TEntity, Tid>.GetAllAsync()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    Task<TEntity> IBaseRepository<TEntity, Tid>.GetByIdAsync(Tid id)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    Task<int> IBaseRepository<TEntity, Tid>.SaveChangesAsync()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    Task<TEntity> IBaseRepository<TEntity, Tid>.UpdateAsync(TEntity entity)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}


}
