using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Infrastractions.Repositores
{
    public class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(EcommerceContext _context) : base(_context)
        {

        }
    }
}
