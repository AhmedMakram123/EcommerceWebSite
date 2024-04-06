using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.Products;
using EcommerceWebSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public SubCategoryService(ISubCategoryRepository _SubCategory,IProductRepository product, IMapper _mapper)
        {
            this.subCategoryRepository = _SubCategory;
            this.productRepository = product;
            this.mapper = _mapper;
        }
        public async Task<List<CreateOrUpdateSubCategoryDTO>> GetAll()
        {
            var Subcat = await subCategoryRepository.GetAllAsync();
            return mapper.Map<List<CreateOrUpdateSubCategoryDTO>>(Subcat);
        }
        public async Task<CreateOrUpdateSubCategoryDTO> Save()
        {
            var res = await subCategoryRepository.SaveChangesAsync();
            return mapper.Map<CreateOrUpdateSubCategoryDTO>(res);
        }

        public async Task<CreateOrUpdateSubCategoryDTO> Update(int id, CreateOrUpdateSubCategoryDTO category)
        {

            var existingCategory = await subCategoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {

                return null;
            }
            existingCategory.EnName = category.EnName;
            existingCategory.ArName = category.ArName;
            existingCategory.CategoryId= category.CategoryId;
            var updatedCategory = await subCategoryRepository.UpdateAsync(existingCategory);
            await subCategoryRepository.SaveChangesAsync();
            return mapper.Map<CreateOrUpdateSubCategoryDTO>(updatedCategory);
        }
        //public async Task<CreateOrUpdateSubCategoryDTO> Update(CreateOrUpdateSubCategoryDTO Subcategory)
        //{
        //    var Subcat = mapper.Map<SubCategory>(Subcategory);
        //    var Newcat = await subCategoryRepository.UpdateAsync(Subcat);
        //    return mapper.Map<CreateOrUpdateSubCategoryDTO>(Newcat);
        //}
        public async Task<CreateOrUpdateSubCategoryDTO> GetOne(int id)
        {
            var Subcat = await subCategoryRepository.GetByIdAsync(id);
            return mapper.Map<CreateOrUpdateSubCategoryDTO>(Subcat);
        }

        public async Task<ResultView<CreateOrUpdateSubCategoryDTO>> Create(CreateOrUpdateSubCategoryDTO Subcategory)
        {
            var query = await subCategoryRepository.GetAllAsync();
            var OldSubCat = query.Where(p => p.EnName == Subcategory.EnName).FirstOrDefault();
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
        //public async Task<ResultView<CreateOrUpdateSubCategoryDTO>> Delete(CreateOrUpdateSubCategoryDTO Subcategory)
        //{
        //    var Subcat = mapper.Map<SubCategory>(Subcategory);
        //    var OldCat = subCategoryRepository.DeleteAsync(Subcat);
        //    await subCategoryRepository.SaveChangesAsync();
        //    var p = mapper.Map<CreateOrUpdateSubCategoryDTO>(OldCat);
        //    return new ResultView<CreateOrUpdateSubCategoryDTO> { Entity = p, IsSuccess = true, msg = "Deleted Successful" };
        //}

        public async Task<ResultView<CreateOrUpdateSubCategoryDTO>> Delete(int SubcategoryId)
        {

            var Subcategory = await subCategoryRepository.GetByIdAsync(SubcategoryId);

            if (Subcategory == null)
            {
                return new ResultView<CreateOrUpdateSubCategoryDTO>
                {
                    IsSuccess = false,
                    msg = "SubCategory not found"
                };
            }
            var query = await productRepository.GetAllAsync();
            var Product = query.Where(p => p.SubCategoryId== Subcategory.Id).FirstOrDefault();
            if (Product != null)
            {
                return new ResultView<CreateOrUpdateSubCategoryDTO>
                {
                    IsSuccess = false,
                    msg = "Cannot delete SubCategory. Product exist."
                };
            }
            var deletedCategory = await subCategoryRepository.DeleteAsync(Subcategory);
            await subCategoryRepository.SaveChangesAsync();

            var deletedCategoryDTO = mapper.Map<CreateOrUpdateSubCategoryDTO>(deletedCategory);

            return new ResultView<CreateOrUpdateSubCategoryDTO>
            {
                Entity = deletedCategoryDTO,
                IsSuccess = true,
                msg = "Deleted Successfully"
            };
        }

        public async Task<List<GetAllSubCategoryDTO>> getallSubCategoryWithProduct(int SubcategoryId)
        {
            return await (await subCategoryRepository.getallSubCategoryWithProduct(SubcategoryId)).ToListAsync();
        }

        public async Task<List<GetAllProductDTO>> getProductonlyfromSubCategory(int SubcategoryId, int num, int pageNum)
        {
            return await (await subCategoryRepository.getProductonlyfromSubCategory(SubcategoryId, num, pageNum)).ToListAsync();
        }
    }
}
