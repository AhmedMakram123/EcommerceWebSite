using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs.CartItem;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceWebSite.Domain.DTOs.Comment;

namespace EcommerceWebSite.App.Services
{
    public class CommentService:ICommentService
    {
       
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;
        public CommentService(ICommentRepository _Comment, IMapper _mapper)
        {
            this.commentRepository = _Comment;
            this.mapper = _mapper;
        }

        public async Task<ResultView<CommentDto>> Create(CommentDto CommentDto)
        {
			var comment = mapper.Map<Comment>(CommentDto);
			var createdComment = await commentRepository.CreateAsync(comment);
            await commentRepository.SaveChangesAsync();
           
            return new ResultView<CommentDto> { Entity = mapper.Map<CommentDto>(createdComment), IsSuccess = true, msg = "Created Successful" };
        }

        public async Task<ResultView<CommentDto>> Delete(int Id)
        {
            var com = await commentRepository.GetByIdAsync(Id);
            if (com == null)
            {
                return new ResultView<CommentDto>

                {
                    IsSuccess = false,
                    msg = "Comment not found"
                };
            }
            else
            {
                var OldCom = commentRepository.DeleteAsync(com);
                await commentRepository.SaveChangesAsync();
                var p = mapper.Map<CommentDto>(OldCom);
                return new ResultView<CommentDto> { Entity = p, IsSuccess = true, msg = "Deleted Successful" };
            }
        }

        public async Task<List<GetCommentDto>> GetAllCommentsForProduct(int pId)
        {
            var coms = await commentRepository.GetAllCommentsForProductAsync(pId);
            var com = coms
                .Select(b => new GetCommentDto()
                {
                    Id = b.Id,
                    Date = b.Date,
                    ProductId = b.ProductId,
                    review = b.review,
                    quality = b.quality,
                    UserName = b.User.fName+b.User.lName
                }).ToList();
            return com;
        }

        public async Task<List<CommentDto>> GetAll()
        {
            var coms = await commentRepository.GetAllAsync();
			return mapper.Map<List<CommentDto>>(coms);
		}
        public async Task<CommentDto> GetOne(int id)
        {
            var comment = await commentRepository.GetByIdAsync(id);
            return mapper.Map<CommentDto>(comment);
        }

        public async Task<int> Save()
        {
            var res = await commentRepository.SaveChangesAsync();
            return res;
        }

        public async Task<ResultView<CommentDto>> Update(CommentDto CommentDto)
        {
            var Query = (await commentRepository.GetAllAsync());
            var old = Query.Where(e => e.Id == CommentDto.Id).FirstOrDefault();
            if (old != null)
            {
                var b = mapper.Map<Comment>(CommentDto);
                old.review = CommentDto.review;
                old.quality = CommentDto.quality;
                old.ProductId = CommentDto.ProductId;
                var NewCom = await commentRepository.UpdateAsync(old);
                await commentRepository.SaveChangesAsync();
                var bDto = mapper.Map<CommentDto>(NewCom);

                return new ResultView<CommentDto> { Entity = bDto, IsSuccess = true, msg = "updated successfully" };
            }
            else
            {
                return new ResultView<CommentDto> { Entity = null, IsSuccess = false, msg = "not Exist" };

            }



        }


    }
}
