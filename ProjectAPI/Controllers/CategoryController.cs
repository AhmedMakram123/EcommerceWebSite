using EcommerceWebSite.App.Services;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService { get; }

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult> GetCategoryAsync()
        {
            List<CreateOrUpdateCategoryDTO> category = await categoryService.GetAll();
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
        [Authorize(Roles = "Admin")]
        public async Task PostAsync([FromBody] CreateOrUpdateCategoryDTO category)
        {
            CreateOrUpdateCategoryDTO category1 = new CreateOrUpdateCategoryDTO();
            category1.Name = category.Name;
            _ = await categoryService.Create(category1);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task Put(int id, [FromBody] CreateOrUpdateCategoryDTO category)
        {
            CreateOrUpdateCategoryDTO category1 = await categoryService.GetOne(id);

            category1.Name = category.Name;
           
            await categoryService.Update(category1);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromBody] CreateOrUpdateCategoryDTO category)
        {
            await categoryService.Delete(category);
            return Ok();

        }
    }
}
