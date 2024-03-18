using EcommerceWebSite.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public interface ISubCategoryService
    {
        public Task<List<CreateOrUpdateSubCategoryDTO>> GetAll();
        public Task<CreateOrUpdateSubCategoryDTO> GetOne(int id);
        public Task<ResultView<CreateOrUpdateSubCategoryDTO>> Create(CreateOrUpdateSubCategoryDTO SubCategory);
        public Task<CreateOrUpdateSubCategoryDTO> Update(int id, CreateOrUpdateSubCategoryDTO category);
        public Task<ResultView<CreateOrUpdateSubCategoryDTO>> Delete(int id);
        public Task<CreateOrUpdateSubCategoryDTO> Save();
    }
}
