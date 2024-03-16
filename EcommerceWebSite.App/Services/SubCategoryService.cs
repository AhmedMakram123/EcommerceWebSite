using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository subCategoryRepository;
        private readonly IMapper mapper;

        public SubCategoryService(ISubCategoryRepository _SubCategory, IMapper _mapper)
        {
            this.subCategoryRepository = _SubCategory;
            this.mapper = _mapper;
        }
        public async Task<CreateOrUpdateSubCategoryDTO> GetAll()
        {
            var Subcat = await subCategoryRepository.GetAllAsync();
            return mapper.Map<CreateOrUpdateSubCategoryDTO>(Subcat);
        }
        public async Task<CreateOrUpdateSubCategoryDTO> Save()
        {
            var res = await subCategoryRepository.SaveChangesAsync();
            return mapper.Map<CreateOrUpdateSubCategoryDTO>(res);
        }
        public async Task<CreateOrUpdateSubCategoryDTO> Update(CreateOrUpdateSubCategoryDTO Subcategory)
        {
            var Subcat = mapper.Map<SubCategory>(Subcategory);
            var Newcat = await subCategoryRepository.UpdateAsync(Subcat);
            return mapper.Map<CreateOrUpdateSubCategoryDTO>(Newcat);
        }
        public async Task<CreateOrUpdateSubCategoryDTO> GetOne(int id)
        {
            var Subcat = await subCategoryRepository.GetByIdAsync(id);
            return mapper.Map<CreateOrUpdateSubCategoryDTO>(Subcat);
        }

        public async Task<ResultView<CreateOrUpdateSubCategoryDTO>> Create(CreateOrUpdateSubCategoryDTO Subcategory)
        {
            var query = await subCategoryRepository.GetAllAsync();
            var OldSubCat = query.Where(p => p.Name == Subcategory.Name).FirstOrDefault();
            if (OldSubCat != null)
            {
                return new ResultView<CreateOrUpdateSubCategoryDTO> { Entity = null, IsSuccess = false, msg = "Already Exists" };
            }
            else
            {
                var SubCat = mapper.Map<SubCategory>(Subcategory);
                var NewSubCat = await subCategoryRepository.CreateAsync(SubCat);
                await subCategoryRepository.SaveChangesAsync();
                var p = mapper.Map<CreateOrUpdateSubCategoryDTO>(NewSubCat);
                return new ResultView<CreateOrUpdateSubCategoryDTO> { Entity = p, IsSuccess = true, msg = "Created Successful" };
            }
        }
        public async Task<ResultView<CreateOrUpdateSubCategoryDTO>> Delete(CreateOrUpdateSubCategoryDTO Subcategory)
        {
            var Subcat = mapper.Map<SubCategory>(Subcategory);
            var OldCat = subCategoryRepository.DeleteAsync(Subcat);
            await subCategoryRepository.SaveChangesAsync();
            var p = mapper.Map<CreateOrUpdateSubCategoryDTO>(OldCat);
            return new ResultView<CreateOrUpdateSubCategoryDTO> { Entity = p, IsSuccess = true, msg = "Deleted Successful" };
        }
    }
}
