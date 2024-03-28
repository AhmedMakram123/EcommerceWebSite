using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository CategoryRepository;
        private readonly ISubCategoryRepository SubCategoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository _Category, ISubCategoryRepository SubCategory, IMapper _mapper)
        {
            this.CategoryRepository = _Category;
            this.SubCategoryRepository = SubCategory;
            this.mapper = _mapper;
        }
        public async Task<List<CreateOrUpdateCategoryDTO>> GetAll()
        {
            var cat = await CategoryRepository.GetAllAsync();
            return mapper.Map <List<CreateOrUpdateCategoryDTO>>(cat);
        }
        public async Task<CreateOrUpdateCategoryDTO> Save()
        {
            var res = await CategoryRepository.SaveChangesAsync();
            return mapper.Map<CreateOrUpdateCategoryDTO>(res);
        }
      
        public async Task<CreateOrUpdateCategoryDTO> GetOne(int id)
        {
            var cat = await CategoryRepository.GetByIdAsync(id);
            return mapper.Map<CreateOrUpdateCategoryDTO>(cat);
        }

        public async Task<CreateOrUpdateCategoryDTO> Update(int id, CreateOrUpdateCategoryDTO category)
        {
    
            var existingCategory = await CategoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return null;
            }
            existingCategory.EnName = category.EnName;
            existingCategory.ArName = category.ArName;
            existingCategory.imgURL = category.imgURL;
            var updatedCategory = await CategoryRepository.UpdateAsync(existingCategory);
            await CategoryRepository.SaveChangesAsync(); 
            return mapper.Map<CreateOrUpdateCategoryDTO>(updatedCategory);
        }

        public async Task<ResultView<CreateOrUpdateCategoryDTO>> Create(CreateOrUpdateCategoryDTO category)
        {
            var query = await CategoryRepository.GetAllAsync();
            var OldCat = query.Where(p => p.EnName == category.EnName).FirstOrDefault();
            if (OldCat != null)
            {
                return new ResultView<CreateOrUpdateCategoryDTO> { Entity = null, IsSuccess = false, msg = "Already Exists" };
            }
            else
            {
                var Cat = mapper.Map<Category>(category);
                var NewCat = await CategoryRepository.CreateAsync(Cat);
                await CategoryRepository.SaveChangesAsync();
                var p = mapper.Map<CreateOrUpdateCategoryDTO>(NewCat);
                return new ResultView<CreateOrUpdateCategoryDTO> { Entity = p, IsSuccess = true, msg = "Created Successful" };
            }
        }
       
        public async Task<ResultView<CreateOrUpdateCategoryDTO>> Delete(int categoryId)
        {
            
            var category = await CategoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                return new ResultView<CreateOrUpdateCategoryDTO>
                {
                    IsSuccess = false,
                    msg = "Category not found"
                };
            }
            var query = await SubCategoryRepository.GetAllAsync();
            var SubCat = query.Where(p => p.CategoryId==category.Id).FirstOrDefault();
           // var subcategories = await SubCategoryRepository.GetByIdAsync(categoryId);
            if (SubCat != null)
            {
                return new ResultView<CreateOrUpdateCategoryDTO>
                {
                    IsSuccess = false,
                    msg = "Cannot delete category. Subcategories exist."
                };
            }
            var deletedCategory = await CategoryRepository.DeleteAsync(category);
            await CategoryRepository.SaveChangesAsync();

            var deletedCategoryDTO = mapper.Map<CreateOrUpdateCategoryDTO>(deletedCategory);

            return new ResultView<CreateOrUpdateCategoryDTO>
            {
                Entity = deletedCategoryDTO,
                IsSuccess = true,
                msg = "Deleted Successfully"
            };
        }

        public async Task<List<GetAllSubCategoryDTO>> GetCategoryWithSubCategory(int id)
        {
            return await (await CategoryRepository.getallCategoryWithSubCategory(id)).ToListAsync();
        }
    }
}
