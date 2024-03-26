using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.Products;
using EcommerceWebSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EcommerceWebSite.Infrastractions.Repositores
{
   
    public class SubCategoryRepository : BaseRepository<SubCategory, int>, ISubCategoryRepository
    {
        private readonly EcommerceContext context;

        public SubCategoryRepository(EcommerceContext _context) : base(_context)
        {
            context = _context;
        }
        public async Task<IQueryable<GetAllSubCategoryDTO>> getallSubCategoryWithProduct(int SubcategoryId)
        {
            return context.SubCategores.Where(c => c.Id == SubcategoryId).Include(c => c.Products).Select(c => new GetAllSubCategoryDTO() { Id = c.Id, enName = c.EnName, arName=c.ArName, Products = c.Products.ToList() });
        }
    }
}
