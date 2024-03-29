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
        //public async Task<IQueryable<GetAllSubCategoryDTO>> getallSubCategoryWithProduct(int SubcategoryId)
        //{
        //    return context.SubCategores.Where(c => c.Id == SubcategoryId).Include(c => c.Products).Select(c => new GetAllSubCategoryDTO() { Id = c.Id, CategoryId = c.CategoryId, enName = c.EnName, arName = c.ArName, Products = c.Products });
        //}

        public async Task<IQueryable<GetAllSubCategoryDTO>> getallSubCategoryWithProduct(int SubcategoryId)
        {
            return context.SubCategores
                .Where(c => c.Id == SubcategoryId)
                .Include(c => c.Products)
                .Select(c => new GetAllSubCategoryDTO()
                {
                    Id = c.Id,
                    CategoryId = c.CategoryId,
                    enName = c.EnName,
                    arName = c.ArName,
                    Products = c.Products.Select(p => new GetAllProductDTO()
                    {
                        // Select only the required fields from the product
                        id = p.Id,
                        ArName=p.ArName,
                        EnName=p.EnName,
                        Quantity = p.Quantity,
                        Description = p.Description,
                        Price = p.Price,
                        imgURL = p.imgURL,
                        SubCategoryId=p.SubCategoryId
                        // Other properties you need from GetAllProductDTO
                    }).ToList()
                });
        }


    }
}
