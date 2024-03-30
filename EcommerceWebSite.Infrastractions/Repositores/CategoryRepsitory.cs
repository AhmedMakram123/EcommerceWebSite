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

namespace EcommerceWebSite.Infrastractions.Repositores
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        private readonly EcommerceContext context;

        public CategoryRepository(EcommerceContext _context) : base(_context)
        {
            context = _context;
        }

        //public async Task<IQueryable<GetAllCategoryDTO>> getallCategoryWithSubCategory(int categoryId)
        //{
        //    return  context.categories.Where(c => c.Id == categoryId).Include(c => c.SubCategories).Select(c => new GetAllCategoryDTO() { Id = c.Id, Name = c.Name, subCategories = c.SubCategories });
        //}
        public async Task<IQueryable<GetAllCategoryDTO>> getallCategoryAndSubCategoryOFit()
        {
            return context.categories.Include(c => c.SubCategories)
                .Select(c => new GetAllCategoryDTO()
                {
                     Id = c.Id,
                     ArName =c.ArName,
                     EnName =c.EnName,
                     imgURL =c.imgURL,
                     subCategories  = c.SubCategories.Select(p => new GetAllSubCategoryDTO()
                    {
                       Id=p.Id,
                       arName =p.ArName,
                       enName =p.EnName,
                       CategoryId =p.CategoryId,
                         // Other properties you need from GetAllProductDTO
                     }).ToList()
                });
        }

        public async Task<IQueryable<GetAllSubCategoryDTO>> getallCategoryWithSubCategory(int categoryId)
        {
            return context.categories
                .Where(c => c.Id == categoryId)
                .SelectMany(c => c.SubCategories)
                .Select(sc => new GetAllSubCategoryDTO
                {
                    Id = sc.Id,
                    CategoryId = sc.CategoryId,
                    enName = sc.EnName,
                    arName = sc.ArName
                   
                });
        }

    }
}
