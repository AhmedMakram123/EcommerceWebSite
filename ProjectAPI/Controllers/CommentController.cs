using EcommerceWebSite.App.Services;
using EcommerceWebSite.Domain.DTOs.CartItem;
using EcommerceWebSite.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcommerceWebSite.Domain.DTOs.Comment;
using System.Collections.Generic;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommentController : Controller
    {
        

            private ICommentService CommentService { get; }

            public CommentController(ICommentService CommentService)
            {
                this.CommentService = CommentService;
            }
            [HttpGet]
            public async Task<ActionResult> GetCommentAsync(int Id)
            {
                List<CommentDto> Comments = await CommentService.GetAll(Id);
                return Ok(Comments);
            }

            [HttpGet]
            [Route("{id}")]
            public async Task<ActionResult> GetById([FromRoute] int id)
            {
                CommentDto C = await CommentService.GetOne(id);
                return Ok(C);
            }

            [HttpPost]
            public async Task PostAsync([FromBody] CommentDto Dto)
            {
            CommentDto Dto1 = new CommentDto();
                
                Dto1.review=Dto.review;
                Dto1.ProductId=Dto.ProductId;
                Dto1.quality=Dto.quality;
                _ = await CommentService.Create(Dto1);
            }

            [HttpPut("{id}")]
            public async Task Put(int id, [FromBody] CommentDto c)
            {
                CommentDto c1 = await CommentService.GetOne(id);
                c1.review=c.review;
                c1.ProductId=c.ProductId;
                c1.quality=c.quality;
                await CommentService.Update(c1);
            }
            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteAsync(int id)
            {
                await CommentService.Delete(id);
                return Ok();
            }

        }
    }
