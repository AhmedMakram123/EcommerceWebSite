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
        public Task<CreateOrUpdateSubCategoryDTO> GetAll();
        public Task<CreateOrUpdateSubCategoryDTO> GetOne(int id);
        public Task<ResultView<CreateOrUpdateSubCategoryDTO>> Create(CreateOrUpdateSubCategoryDTO SubCategory);
        public Task<CreateOrUpdateSubCategoryDTO> Update(CreateOrUpdateSubCategoryDTO SubCategory);
        public Task<ResultView<CreateOrUpdateSubCategoryDTO>> Delete(CreateOrUpdateSubCategoryDTO SubCategory);
        public Task<CreateOrUpdateSubCategoryDTO> Save();
    }
}
