using EcommerceWebSite.App.Services;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService { get; }
        private IProductService productService { get; }

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult> GetCategoryAsync()
        {
            List<CreateOrUpdateCategoryDTO> category = await categoryService.GetAll();
            return Ok(category);
        }

        [HttpGet("{id}/GetAllCategoryAndSubAsync")]
        //[HttpGet("GetAllCategoryAndSubAsync")]
        public async Task<ActionResult> GetAllCategoryAndSubAsync([FromRoute] int id)
        {
            List<GetAllSubCategoryDTO> category = await categoryService.GetCategoryWithSubCategory(id);
            return Ok(category);
        }
        [HttpGet("{id}/getAllProductByCategory")]
        //[HttpGet("GetAllCategoryAndSubAsync")]
        public async Task<ActionResult> getAllProductByCategory([FromRoute] int id, int num, int pageNum)
        {
            List<Product> category = await productService.getAllProductByCategory(id, num, pageNum);
            return Ok(category);
        }

        [HttpGet("getallCategoryAndSubCategoryOFit")]
        //[HttpGet("GetAllCategoryAndSubAsync")]
        public async Task<ActionResult> getallCategoryAndSubCategoryOFit()
        {
            List<GetAllCategoryDTO> category = await categoryService.getallCategoryAndSubCategoryOFit();
            return Ok(category);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            CreateOrUpdateCategoryDTO C = await categoryService.GetOne(id);
            return Ok(C);
        }

        [HttpPost]
      // [Authorize(Roles = "Admin")]
        public async Task PostAsync([FromBody] CreateOrUpdateCategoryDTO category)
        {
            CreateOrUpdateCategoryDTO category1 = new CreateOrUpdateCategoryDTO();
            category1.EnName = category.EnName;
            category1.ArName = category.ArName;
            category1.imgURL= category.imgURL;
            category1.imgURLAr = category.imgURLAr;
            
            await categoryService.Create(category1);
        }

        
        [HttpPut("{id}")]
       // [Authorize(Roles = "Admin")]
        public async Task Put(int id, [FromBody] CreateOrUpdateCategoryDTO category)
        {
            CreateOrUpdateCategoryDTO category1 = await categoryService.GetOne(id);
            
            category1.EnName = category.EnName;
            category1.ArName = category.ArName;
            category1.imgURL = category.imgURL;
            category1.imgURLAr= category.imgURLAr; 
            await categoryService.Update(id,category1);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await categoryService.Delete(id);
            if (!result.IsSuccess)
            {
                return StatusCode(500, new { Message = result.msg });
            }
            return Ok();
        }

    }
}
