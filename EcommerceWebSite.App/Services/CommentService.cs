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
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        public CommentService(ICommentService _Comment, IMapper _mapper)
        {
            this.commentService = _Comment;
            this.mapper = _mapper;
        }

        public async Task<ResultView<CommentDto>> Create(CommentDto CommentDto)
        {
            var NewCom = await commentService.Create(CommentDto);
            await commentService.Save();
            var p = mapper.Map<CommentDto>(NewCom);
            return new ResultView<CommentDto> { Entity = p, IsSuccess = true, msg = "Created Successful" };
        }

        public async Task<ResultView<CommentDto>> Delete(int Id)
        {
            var com = await commentService.GetOne(Id);
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
                var OldCom = commentService.Delete(Id);
                await commentService.Save();
                var p = mapper.Map<CommentDto>(OldCom);
                return new ResultView<CommentDto> { Entity = p, IsSuccess = true, msg = "Deleted Successful" };
            }
        }

        public async Task<ResultDataList<CommentDto>> GetAll()
        {
            var coms = await commentService.GetAll();
            var com = coms.Entities.Select(e => new CommentDto()
                {
                    Id = e.Id,
                    quality = e.quality,
                    review= e.review,
                    ProductId= e.ProductId,
                }).ToList();
            ResultDataList<CommentDto> resultDataList = new ResultDataList<CommentDto>();
            resultDataList.Entities = com.ToList();
            resultDataList.Count = com.Count();
            return resultDataList;



        }

        public async Task<CommentDto> GetOne(int id)
        {
            var cat = await commentService.GetOne(id);
            return mapper.Map<CommentDto>(cat);

        }

        public async Task<int> Save()
        {
            var res = await commentService.Save();
            return res;

        }

        public async Task<ResultView<CommentDto>> Update(CommentDto CommentDto)
        {
            var Query = (await commentService.GetAll());
            var old = Query.Entities.Where(e => e.Id==CommentDto.Id).FirstOrDefault();
            if (old != null)
            {
                var b = mapper.Map<Comment>(CommentDto);
                old.review = CommentDto.review;
                old.quality = CommentDto.quality;
                old.ProductId = CommentDto.ProductId;
                var NewCom = await commentService.Update(old);
                await commentService.Save();
                var bDto = mapper.Map<CommentDto>(NewCom);

                return new ResultView<CommentDto> { Entity = bDto, IsSuccess = true, msg = "updated successfully" };
            }
            else
            {
                return new ResultView<CommentDto> { Entity = null, IsSuccess = false, msg = "Already Exist" };

            }



        }


    }
}
