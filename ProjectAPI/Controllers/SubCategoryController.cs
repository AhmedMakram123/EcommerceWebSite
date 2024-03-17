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
    public class SubCategoryController : ControllerBase
    {
        private ISubCategoryService subcategoryService { get; }

        public SubCategoryController(ISubCategoryService subcategoryService)
        {
            this.subcategoryService = subcategoryService;
        }
        [HttpGet]
        public async Task<ActionResult> GetCategoryAsync()
        {
            List<CreateOrUpdateSubCategoryDTO> category = await subcategoryService.GetAll();
            return Ok(category);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            CreateOrUpdateSubCategoryDTO C = await subcategoryService.GetOne(id);
            return Ok(C);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task PostAsync([FromBody] CreateOrUpdateSubCategoryDTO subcategory)
        {
            CreateOrUpdateSubCategoryDTO subcategory1 = new CreateOrUpdateSubCategoryDTO();
            subcategory1.Name = subcategory.Name;
            _ = await subcategoryService.Create(subcategory1);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task Put(int id, [FromBody] CreateOrUpdateSubCategoryDTO subcategory)
        {
            CreateOrUpdateSubCategoryDTO category1 = await subcategoryService.GetOne(id);

            category1.Name = subcategory.Name;

            await subcategoryService.Update(category1);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromBody] CreateOrUpdateSubCategoryDTO subcategory)
        {
            await subcategoryService.Delete(subcategory);
            return Ok();

        }
    }
}
