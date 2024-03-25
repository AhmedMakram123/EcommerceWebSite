using EcommerceWebSite.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public interface ICategoryService
    {
       
        public Task<List<CreateOrUpdateCategoryDTO>> GetAll();
        public Task<CreateOrUpdateCategoryDTO> GetOne(int id);
        public Task<ResultView<CreateOrUpdateCategoryDTO>> Create(CreateOrUpdateCategoryDTO category);
        public Task<CreateOrUpdateCategoryDTO> Update(int id, CreateOrUpdateCategoryDTO category);
        public Task<ResultView<CreateOrUpdateCategoryDTO>> Delete(int id);
        public Task<CreateOrUpdateCategoryDTO> Save();
        public Task<List<GetAllCategoryDTO>> GetCategoryWithSubCategory();
    }
}
