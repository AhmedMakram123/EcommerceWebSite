using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.DTOs.Products;
using EcommerceWebSite.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.Infrastractions.Repositores
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        private readonly EcommerceContext context;

        public ProductRepository(EcommerceContext _context) : base(_context)
        {
            context = _context;
        }

        public async  Task<IQueryable<Product>> getAllProductByCategory(int CategoryId, int num, int pageNum)
        {
            var query = from prod in context.products
                        join sub in context.SubCategores
                        on prod.SubCategoryId equals sub.Id
                        join cat in context.categories
                        on sub.CategoryId equals cat.Id
                        where cat.Id == CategoryId
                        select prod;

            //return  query;
            return query.Skip(num*(pageNum-1)).Take(num);
 
        }
        //public async Task<List<GetAllProductDTO>> GetAllPaginationOfProduct(int num, int pageNum)
        //{
        //    var products = await productRepository.GetAllAsync();
        //    var query = products.Skip(num * (pageNum - 1)).Take(num).ToList();
        //    return mapper.Map<List<GetAllProductDTO>>(query);
        //}
    }
}

