using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Contract
{
    public interface ICategoryRepository: IBaseRepository<Category,int>
    {
        // public Task<IQueryable<GetAllCategoryDTO>> getallCategoryWithSubCategory(int id);
        public Task<IQueryable<GetAllSubCategoryDTO>> getallCategoryWithSubCategory(int categoryId);
    }
   
}
