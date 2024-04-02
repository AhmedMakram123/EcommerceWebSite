using EcommerceWebSite.Domain.DTOs.Comment;
using EcommerceWebSite.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public interface ICommentService
    {
            public Task<List<CommentDto>> GetAll();
            public Task<List<CommentDto>> GetAllCommentsForProduct(int PId);
            public Task<CommentDto> GetOne(int id);
            public Task<ResultView<CommentDto>> Create(CommentDto CommentDto);
            public Task<ResultView<CommentDto>> Update(CommentDto CommentDto);
            public Task<ResultView<CommentDto>> Delete(int Id);
            public Task<int> Save();

        }
    }
